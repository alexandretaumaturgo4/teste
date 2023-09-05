using Backoffice.Application.Services.Authentication;
using Backoffice.Application.Services.Authentication.Requests;
using Backoffice.Application.Services.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backoffice.Presentation.API.Controllers;

[Route("api/[controller]")]
public class AuthController : MainController
{
    private readonly IAuthenticationService _authenticationService;

    public AuthController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("cadastrar")]
    [Authorize(Roles = "administrador")]
    public async Task<IActionResult> CadastrarUsuario(CriarUsuarioRequest criarUsuarioRequest)
    {
        var response = await _authenticationService.CriarUsuario(criarUsuarioRequest);
        return ApiResult(response);
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Autenticar(LoginRequest loginRequest)
    {
        var response = await _authenticationService.Login(loginRequest);
        return ApiResult(response);
    }

    [HttpGet("listar")]
    [AllowAnonymous]
    public async Task<IActionResult> ListarUsuarios()
    {
        var response = await _authenticationService.ListarUsuarios();
        return ApiResult(response);
    }

    [HttpPut("desativar/{idUsuario:guid}")]
    public async Task<IActionResult> DesativarUsuario(Guid idUsuario)
    {
        var response = await _authenticationService.DesativarUsuario(idUsuario);
        return ApiResult(response);
    }

    [HttpPut("recuperar-senha")]
    public async Task<IActionResult> RecuperarSenha(string userName)
    {
        var response = await _authenticationService.RecuperarSenha(userName);
        return ApiResult(response);
    }

    [HttpPost("mudar-senha-usuario")]
    public async Task<IActionResult> ResetarSenhaUsuario(string email, string senha)
    {
        var response = await _authenticationService.ResetarSenhaUsuario(email, senha);
        return ApiResult(response);
    }
}