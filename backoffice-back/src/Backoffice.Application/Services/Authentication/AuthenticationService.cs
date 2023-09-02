using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Backoffice.Application.Services.Authentication.Requests;
using Backoffice.Application.Services.Authentication.Responses;
using Backoffice.Application.Services.Base;
using Backoffice.Core;
using Backoffice.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Backoffice.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly Jwt _jwt;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IMapper _mapper;

    public AuthenticationService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
        RoleManager<IdentityRole> roleManager,
        IOptions<Jwt> jwtOptions, IMapper mapper)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _jwt = jwtOptions.Value;
        _mapper = mapper;
    }

    public async Task<BaseResponse<LoginResponse>> Login(LoginRequest loginRequest)
    {
        var user = await _userManager.FindByNameAsync(loginRequest.UserName);
        if (user == null)
        {
            return new BaseResponse<LoginResponse>(false, null, "Usuário ou senha incorretos.");
        }

        var signIn = await _signInManager.PasswordSignInAsync(user, loginRequest.Senha, false, false);
        if (!signIn.Succeeded)
        {
            return new BaseResponse<LoginResponse>(false, null, "Usuário ou senha incorretos.");
        }

        var loginResponse = await GenerateToken(user);

        return new BaseResponse<LoginResponse>(true, loginResponse);
    }

    public async Task<BaseResponse> CriarUsuario(CriarUsuarioRequest criarUsuarioRequest)
    {
        var userExists = (await _userManager.FindByEmailAsync(criarUsuarioRequest.Email)) is not null;
        if (userExists)
        {
            return new BaseResponse(false, "Usuário já cadastrado com esse e-mail. Por favor revise-o.");
        }

        var user = new IdentityUser
        {
            UserName = criarUsuarioRequest.UserName,
            Email = criarUsuarioRequest.Email,
            EmailConfirmed = true
        };

        var createdUser = await _userManager.CreateAsync(user, "Admin@123");
        if (!createdUser.Succeeded)
        {
            return new BaseResponse(false,
                createdUser.Errors.FirstOrDefault().Description);
        }

        var cargo = Roles.usuario.ToString();

        await _userManager.AddToRoleAsync(user, cargo);

        return new BaseResponse(createdUser.Succeeded);
    }

    public async Task<BaseResponse<IEnumerable<BuscarUsuarioResponse>>> ListarUsuarios()
    {
        var users =
            await _userManager.GetUsersInRoleAsync("usuario");

        var response = _mapper.Map<List<BuscarUsuarioResponse>>(users);

        return new BaseResponse<IEnumerable<BuscarUsuarioResponse>>(true, response);
    }

    public async Task<BaseResponse> DesativarUsuario(Guid idUsuario)
    {
        var user = await _userManager.FindByIdAsync(idUsuario.ToString());
        if (user == null)
        {
            return new BaseResponse(false, "usuário não encontrado.");
        }

        user.EmailConfirmed = false;

        await _userManager.UpdateAsync(user);

        return new BaseResponse(true, "Usuário desativado");
    }

    private async Task<LoginResponse> GenerateToken(IdentityUser user)
    {
        var claims = await GetUserClaims(user);
        var identityClaims = new ClaimsIdentity(claims);

        var loginResponse = new LoginResponse
        {
            Token = WriteToken(identityClaims),
            Email = user.Email,
            Role = identityClaims.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value
        };

        return loginResponse;
    }

    private async Task<IEnumerable<Claim>> GetUserClaims(IdentityUser user)
    {
        var userRoles = await _userManager.GetRolesAsync(user);
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id),
            new(JwtRegisteredClaimNames.Email, user.Email),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()),
            new(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(),
                ClaimValueTypes.Integer64)
        };

        claims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

        return claims;
    }

    private long ToUnixEpochDate(DateTime date)
        => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero))
            .TotalSeconds);

    private string WriteToken(ClaimsIdentity identityClaims)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Secret));
        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

        var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
        {
            Issuer = _jwt.Issuer,
            Subject = identityClaims,
            Expires = DateTime.UtcNow.AddHours(_jwt.ExpirationInHours),
            SigningCredentials = signingCredentials
        });

        return tokenHandler.WriteToken(token);
    }
}