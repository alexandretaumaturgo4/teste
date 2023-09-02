using Backoffice.Domain.Entities;

namespace Backoffice.Domain.Repository;

public interface IPessoaRepository
{
    Task AdicionarPessoa(Pessoa pessoa); 
    Task<bool> PessoaExistePorId(Guid id);
    Task<IEnumerable<Pessoa>> BuscarPessoas();
    Task<Pessoa> BuscarPorDocumento(string documento);
    Task<IEnumerable<Pessoa>> BuscarColaboradores();
    Task<IEnumerable<Pessoa>> BuscarPessoasFisicas();
    Task<IEnumerable<Pessoa>> BuscarPessoasJuridicas();
}