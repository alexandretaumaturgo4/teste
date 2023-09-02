namespace Backoffice.Application.Services.Pessoas.Requests;

public abstract class BasePessoaRequest
{
    public short Qualificacao { get; set; }
    public string Cep { get; set; }
    public string Rua { get; set; }
    public string Numero { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
}