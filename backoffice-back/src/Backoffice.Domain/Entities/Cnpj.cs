namespace Backoffice.Domain.Entities;

public class Cnpj
{
    public string Valor { get; private set; }

    private Cnpj(string valor)
    {
        Valor = valor;
    }

    public static implicit operator Cnpj(string cnpj)
    {
        Validar(cnpj);

        return new Cnpj(cnpj);
    }

    private static void Validar(string cnpj)
    {
    }
}