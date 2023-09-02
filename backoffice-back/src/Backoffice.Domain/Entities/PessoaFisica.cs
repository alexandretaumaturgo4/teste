namespace Backoffice.Domain.Entities;

public class PessoaFisica : Entity
{
    public string Nome { get; set; }
    public string Apelido { get; set; }
    public Cpf Cpf { get; private set; }

    public PessoaFisica(string nome, string apelido, Cpf cpf)
    {
        Nome = nome;
        Apelido = apelido;
        Cpf = cpf;
    }

    protected PessoaFisica()
    {
    }
}