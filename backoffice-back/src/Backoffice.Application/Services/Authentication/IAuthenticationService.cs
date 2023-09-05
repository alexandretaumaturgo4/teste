using Backoffice.Application.Services.Authentication.Requests;
using Backoffice.Application.Services.Authentication.Responses;
using Backoffice.Application.Services.Base;

namespace Backoffice.Application.Services.Authentication;

public interface IAuthenticationService
{
    Task<BaseResponse<LoginResponse>> Login(LoginRequest loginRequest);
    Task<BaseResponse> CriarUsuario(CriarUsuarioRequest criarUsuarioRequest);
    Task<BaseResponse<IEnumerable<BuscarUsuarioResponse>>> ListarUsuarios();
    Task<BaseResponse> DesativarUsuario(Guid idUsuario);
    Task<BaseResponse> RecuperarSenha(string userName);
    Task<BaseResponse> ResetarSenhaUsuario(string email, string senha);
}