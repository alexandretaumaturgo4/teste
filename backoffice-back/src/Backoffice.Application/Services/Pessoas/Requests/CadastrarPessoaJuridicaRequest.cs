namespace Backoffice.Application.Services.Pessoas.Requests;

public class CadastrarPessoaJuridicaRequest : BasePessoaRequest
{
    public string RazaoSocial { get; set; }
    public string NomeFantasia { get; set; }
    public string Cnpj { get; set; }
}