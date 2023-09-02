namespace Backoffice.Application.Services.Authentication.Responses;

public class BuscarUsuarioResponse
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public bool Ativo { get; set; }
}