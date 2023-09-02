using Backoffice.Domain.Entities;
using Backoffice.Domain.Repository;
using Backoffice.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Backoffice.Infra.Data.Repository;

public class DepartamentoRepository : IDepartamentoRepository
{
    private readonly BackofficeContext _context;

    public DepartamentoRepository(BackofficeContext context)
    {
        _context = context;
    }

    public async Task AdicionarDepartamento(Departamento departamento)
    {
        await _context.Departamentos.AddAsync(departamento);

        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Departamento>> BuscarDepartamentos()
    {
        var response =
            await _context.Departamentos
                .Include(x => x.Responsavel)
                .Include(x => x.Responsavel.PessoaFisica)
                .Include(x => x.Responsavel.PessoaJuridica)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();

        return response;
    }

    public async Task<Departamento> BuscarPorId(Guid id)
    {
        var response = await _context.Departamentos.FindAsync(id);

        return response;
    }

    public async Task<Departamento> BuscarPorNome(string nome)
    {
        var departamento = await _context.Departamentos.FirstOrDefaultAsync(x => x.Nome == nome);
        return departamento;
    }
}