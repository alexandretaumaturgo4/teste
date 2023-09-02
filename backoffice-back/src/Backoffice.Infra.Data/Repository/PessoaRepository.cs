using Backoffice.Domain.Entities;
using Backoffice.Domain.Repository;
using Backoffice.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Backoffice.Infra.Data.Repository;

public class PessoaRepository : IPessoaRepository
{
    private readonly BackofficeContext _context;

    public PessoaRepository(BackofficeContext context)
    {
        _context = context;
    }

    public async Task AdicionarPessoa(Pessoa pessoa)
    {
        await _context.Pessoas.AddAsync(pessoa);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> PessoaExistePorId(Guid id)
    {
        var pessoaExiste = await _context.Pessoas.AnyAsync(x => x.Id == id);
        return pessoaExiste;
    }
    
    public async Task<IEnumerable<Pessoa>> BuscarPessoasFisicas()
    {
        var pessoas = await _context.Pessoas
            .Include(x => x.PessoaFisica)
            .Where(x => x.PessoaFisica != null)
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync();
 

        return pessoas;
    }

    public async Task<IEnumerable<Pessoa>> BuscarPessoasJuridicas()
    {
        var pessoas = await _context.Pessoas
            .Include(x => x.PessoaJuridica)
            .Where(x => x.PessoaJuridica != null)
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync();

        return pessoas;
    }

    public async Task<IEnumerable<Pessoa>> BuscarPessoas()
    {
        var pessoas = await _context.Pessoas
            .Include(x => x.PessoaFisica)
            .Include(x => x.PessoaJuridica)
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync();

        return pessoas;
    }

    public async Task<Pessoa> BuscarPorDocumento(string documento)
    {
        var pessoa = await _context.Pessoas
            .Include(x => x.PessoaFisica)
            .Include(x => x.PessoaJuridica)
            .FirstOrDefaultAsync(x =>
                x.PessoaFisica.Cpf.Valor == documento || x.PessoaJuridica.Cnpj.Valor == documento);

        return pessoa;
    }

    public async Task<IEnumerable<Pessoa>> BuscarColaboradores()
    {
        var response = await _context.Pessoas
            .Include(x => x.PessoaFisica)
            .Include(x => x.PessoaJuridica)
            .Where(x => x.Qualificacao == Qualificacao.Colaborador)
            .ToListAsync();

        return response;
    }
}