namespace Backoffice.Application.Services.Pessoas.Responses;

public class BuscarPessoasJuridicasResponse : BuscarPessoasBase
{
    public string RazaoSocial { get; set; }
    public string NomeFantasia { get; set; }
    public string Cnpj { get; set; }
}