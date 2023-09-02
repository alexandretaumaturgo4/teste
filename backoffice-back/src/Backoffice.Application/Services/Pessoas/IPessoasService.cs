using Backoffice.Application.Services.Base;
using Backoffice.Application.Services.Pessoas.Requests;
using Backoffice.Application.Services.Pessoas.Responses;

namespace Backoffice.Application.Services.Pessoas;

public interface IPessoasService
{
    Task<BaseResponse> CadastrarPessoaFisica(CadastrarPessoaFisicaRequest request);
    Task<BaseResponse<IEnumerable<BuscarPessoaFisicaResponse>>> BuscarPessoasFisicas();
    Task<BaseResponse<IEnumerable<BuscarPessoasJuridicasResponse>>> BuscarPessoasJuridicas();
    Task<BaseResponse> CadastrarPessoaJuridica(CadastrarPessoaJuridicaRequest request);
    Task<BaseResponse<IEnumerable<BuscarPessoasColaboradorasResponse>>> BuscarColaboradores();
}