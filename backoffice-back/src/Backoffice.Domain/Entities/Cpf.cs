namespace Backoffice.Domain.Entities;

public class  Cpf
{
    public string Valor { get; private set; }

    private Cpf(string valor)
    {
        Valor = valor;
    }

    public static implicit operator Cpf(string cpf)
    {
        Validar(cpf);

        return new Cpf(cpf);
    }

    private static void Validar(string cpf)
    {
    }
}