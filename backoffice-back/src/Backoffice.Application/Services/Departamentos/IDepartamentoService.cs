using Backoffice.Application.Services.Base;
using Backoffice.Application.Services.Departamentos.Responses;

namespace Backoffice.Application.Services.Departamentos;

public interface IDepartamentoService
{
    Task<BaseResponse> CriarDepartamento(CriarDepartamentoRequest request);
    Task<BaseResponse<IEnumerable<BuscarDepartamentoResponse>>> BuscarDepartamentos();
}