using Backoffice.Application.Services.Departamentos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backoffice.Presentation.API.Controllers;

[Authorize]
[Route("api/[controller]")]
public class DepartamentosController : MainController
{
    private readonly IDepartamentoService _departamentoService;

    public DepartamentosController(IDepartamentoService departamentoService)
    {
        _departamentoService = departamentoService;
    }

    [HttpPost]
    [Authorize(Roles = "usuario,administrador")]
    public async Task<IActionResult> CriarDepartamento(CriarDepartamentoRequest request)
    {
        var response = await _departamentoService.CriarDepartamento(request);
        return ApiResult(response);
    }

    [HttpGet]
    [Authorize(Roles = "usuario,administrador")]
    public async Task<IActionResult> BuscarDepartamentos()
    {
        var response = await _departamentoService.BuscarDepartamentos();
        return ApiResult(response);
    }
}