namespace Backoffice.Application.Services.Pessoas.Responses;

public abstract class BuscarPessoasBase
{
    public Guid Id { get; set; }
    public string Qualificacao { get; set; }
    public string Cep { get; set; }
    public string Rua { get; set; }
    public string Numero { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public DateTime CriadoEm { get; set; }
    public DateTime AtualizadoEm { get; set; }
}