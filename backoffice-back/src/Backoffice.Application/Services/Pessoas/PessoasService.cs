using AutoMapper;
using Backoffice.Application.Services.Base;
using Backoffice.Application.Services.Pessoas.Requests;
using Backoffice.Application.Services.Pessoas.Responses;
using Backoffice.Domain.Entities;
using Backoffice.Domain.Repository;

namespace Backoffice.Application.Services.Pessoas;

public class PessoasService : IPessoasService
{
    private readonly IPessoaRepository _pessoaRepository;
    private readonly IMapper _mapper;

    public PessoasService(IPessoaRepository pessoaRepository, IMapper mapper)
    {
        _pessoaRepository = pessoaRepository;
        _mapper = mapper;
    }

    public async Task<BaseResponse> CadastrarPessoaFisica(CadastrarPessoaFisicaRequest request)
    {
        return await CadastrarPessoaFromRequest(request, request.Cpf);
    }

    public async Task<BaseResponse<IEnumerable<BuscarPessoasJuridicasResponse>>> BuscarPessoasJuridicas()
    {
        var pessoas = await _pessoaRepository.BuscarPessoasJuridicas();

        var result = _mapper.Map<List<BuscarPessoasJuridicasResponse>>(pessoas);

        return new BaseResponse<IEnumerable<BuscarPessoasJuridicasResponse>>(true, result);
    }

    public async Task<BaseResponse> CadastrarPessoaJuridica(CadastrarPessoaJuridicaRequest request)
    {
        return await CadastrarPessoaFromRequest(request, request.Cnpj);
    }

    public async Task<BaseResponse<IEnumerable<BuscarPessoasColaboradorasResponse>>> BuscarColaboradores()
    {
        var response = await _pessoaRepository.BuscarColaboradores();

        return new BaseResponse<IEnumerable<BuscarPessoasColaboradorasResponse>>(true,
            _mapper.Map<List<BuscarPessoasColaboradorasResponse>>(response));
    }

    public async Task<BaseResponse<IEnumerable<BuscarPessoaFisicaResponse>>> BuscarPessoasFisicas()
    {
        var pessoas = await _pessoaRepository.BuscarPessoasFisicas();

        var result = _mapper.Map<List<BuscarPessoaFisicaResponse>>(pessoas);

        return new BaseResponse<IEnumerable<BuscarPessoaFisicaResponse>>(true, result);
    }

    private async Task<BaseResponse> CadastrarPessoaFromRequest<TRequest>(TRequest request, string documento)
        where TRequest : BasePessoaRequest
    {
        if (await DocumentoEmUso(documento))
        {
            return new BaseResponse(false, "Documento já está sendo utilizado.");
        }

        var pessoa = CreatePessoaFromRequest(request);
        return await AddPessoaToRepository(pessoa);
    }

    private async Task<bool> DocumentoEmUso(string documento)
    {
        return (await _pessoaRepository.BuscarPorDocumento(documento)) is not null;
    }

    private Pessoa CreatePessoaFromRequest(BasePessoaRequest request)
    {
        Endereco endereco = new(request.Cep, request.Rua, request.Numero, request.Bairro, request.Cidade,
            request.Estado);

        switch (request)
        {
            case CadastrarPessoaFisicaRequest pessoaFisicaRequest:
            {
                var pessoaFisica = new PessoaFisica(pessoaFisicaRequest.Nome, pessoaFisicaRequest.Apelido,
                    pessoaFisicaRequest.Cpf);
                return new Pessoa((Qualificacao)pessoaFisicaRequest.Qualificacao, endereco, pessoaFisica);
            }
            case CadastrarPessoaJuridicaRequest pessoaJuridicaRequest:
            {
                var pessoaJuridica = new PessoaJuridica(pessoaJuridicaRequest.RazaoSocial,
                    pessoaJuridicaRequest.NomeFantasia, pessoaJuridicaRequest.Cnpj);
                return new Pessoa((Qualificacao)pessoaJuridicaRequest.Qualificacao, endereco, pessoaJuridica);
            }
            default:
                throw new ArgumentException("Tipo de request inválido.");
        }
    }

    private async Task<BaseResponse> AddPessoaToRepository(Pessoa pessoa)
    {
        await _pessoaRepository.AdicionarPessoa(pessoa);
        return new BaseResponse(true);
    }
}