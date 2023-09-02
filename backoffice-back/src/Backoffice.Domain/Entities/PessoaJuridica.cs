namespace Backoffice.Domain.Entities;

public class PessoaJuridica : Entity
{
    public string RazaoSocial { get; private set; }
    public string NomeFantasia { get; private set; }
    public Cnpj Cnpj { get; private set; }


    public PessoaJuridica(string razaoSocial, string nomeFantasia, string cnpj)
    {
        RazaoSocial = razaoSocial;
        NomeFantasia = nomeFantasia;
        Cnpj = cnpj;
    }

    protected PessoaJuridica()
    {
    }
}