namespace Backoffice.Domain.Entities;

public class Departamento : Entity
{
    public string Nome { get; private set; }
    public Guid ResponsavelId { get; private set; }
    public Pessoa Responsavel { get; private set; }

    public Departamento(string nome, Guid responsavelId)
    {
        Nome = nome;
        ResponsavelId = responsavelId;
    }

    protected Departamento()
    {
    }
}

