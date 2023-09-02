using AutoMapper;
using Backoffice.Application.Services.Base;
using Backoffice.Application.Services.Departamentos.Responses;
using Backoffice.Domain.Entities;
using Backoffice.Domain.Repository;

namespace Backoffice.Application.Services.Departamentos;

public class DepartamentoService : IDepartamentoService
{
    private readonly IDepartamentoRepository _departamentoRepository;
    private readonly IPessoaRepository _pessoaRepository;
    private readonly IMapper _mapper;

    public DepartamentoService(IDepartamentoRepository departamentoRepository, IPessoaRepository pessoaRepository,
        IMapper mapper)
    {
        _departamentoRepository = departamentoRepository;
        _pessoaRepository = pessoaRepository;
        _mapper = mapper;
    }

    public async Task<BaseResponse> CriarDepartamento(CriarDepartamentoRequest request)
    {
        var departamentoExiste = (await _departamentoRepository.BuscarPorNome(request.Nome)) is not null;
        if (departamentoExiste)
        {
            return new BaseResponse(false, "Departamento com esse nome já existente.");
        }

        var responsavel = await _pessoaRepository.BuscarPorDocumento(request.DocumentoResponsavel);
        if (responsavel is null)
        {
            return new BaseResponse(false, "Responsável não existente. Por favor verificar.");
        }

        if (!VerificarSeResponsavelEhColaborador(responsavel))
        {
            return new BaseResponse(false,
                "Para vincular um departamento a uma pessoa, ela precisa ser colaboradora. Favor verificar.");
        }

        var departamento = new Departamento(request.Nome, responsavel.Id);

        await _departamentoRepository.AdicionarDepartamento(departamento);

        return new BaseResponse(true);
    }

    public async Task<BaseResponse<IEnumerable<BuscarDepartamentoResponse>>> BuscarDepartamentos()
    {
        var departamentos = await _departamentoRepository.BuscarDepartamentos();

        var response = _mapper.Map<List<BuscarDepartamentoResponse>>(departamentos);

        return new BaseResponse<IEnumerable<BuscarDepartamentoResponse>>(true, response);
    }

    private bool VerificarSeResponsavelEhColaborador(Pessoa responsavel)
    {
        return responsavel.Qualificacao is Qualificacao.Colaborador;
    }
}