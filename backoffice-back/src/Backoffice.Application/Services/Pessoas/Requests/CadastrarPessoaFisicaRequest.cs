using Backoffice.Domain.Entities;

namespace Backoffice.Application.Services.Pessoas.Requests;

public class CadastrarPessoaFisicaRequest : BasePessoaRequest
{
    public string Nome { get; set; }
    public string Apelido { get; set; }
    public string Cpf { get; set; } 
}