namespace Backoffice.Application.Services.Pessoas.Responses;

public class BuscarPessoaFisicaResponse : BuscarPessoasBase
{
    public string Nome { get; set; }
    public string Apelido { get; set; }
    public string Cpf { get; set; }
}