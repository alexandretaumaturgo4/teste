namespace Backoffice.Domain.Entities;

public class Pessoa : Entity
{
    public Qualificacao Qualificacao { get; private set; }
    public Endereco Endereco { get; private set; }
    public TipoPessoa TipoPessoa { get; private set; }

    public Guid? PessoaFisicaId { get; private set; }
    public PessoaFisica PessoaFisica { get; set; }

    public Guid? PessoaJuridicaId { get; private set; }
    public PessoaJuridica PessoaJuridica { get; set; }

    protected Pessoa() {}

    public Pessoa(Qualificacao qualificacao, Endereco endereco, PessoaFisica pessoaFisica)
    {
        Qualificacao = qualificacao;
        Endereco = endereco;
        TipoPessoa = TipoPessoa.Fisica;
        
        AssociarPessoaFisica(pessoaFisica);
    }

    public Pessoa(Qualificacao qualificacao, Endereco endereco, PessoaJuridica pessoaJuridica)
    {
        Qualificacao = qualificacao;
        Endereco = endereco;
        TipoPessoa = TipoPessoa.Juridica;
        
        AssociarPessoaJuridica(pessoaJuridica);
    }

    private void AssociarPessoaFisica(PessoaFisica pessoaFisica)
    {
        if (TipoPessoa != TipoPessoa.Fisica)
            throw new InvalidOperationException("Tipo de pessoa incompatível");

        PessoaFisica = pessoaFisica;
        PessoaFisicaId = pessoaFisica?.Id;
    }

    private void AssociarPessoaJuridica(PessoaJuridica pessoaJuridica)
    {
        if (TipoPessoa != TipoPessoa.Juridica)
            throw new InvalidOperationException("Tipo de pessoa incompatível");

        PessoaJuridica = pessoaJuridica;
        PessoaJuridicaId = pessoaJuridica?.Id;
    }
}