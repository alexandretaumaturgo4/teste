using Backoffice.Domain.Entities;

namespace Backoffice.Domain.Repository;

public interface IDepartamentoRepository
{
    Task AdicionarDepartamento(Departamento departamento);
    Task<IEnumerable<Departamento>> BuscarDepartamentos();
    Task<Departamento> BuscarPorId(Guid id);
    Task<Departamento> BuscarPorNome(string nome);
}