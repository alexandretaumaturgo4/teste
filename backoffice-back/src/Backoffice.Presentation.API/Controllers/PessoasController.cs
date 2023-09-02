using Backoffice.Application.Services.Pessoas;
using Backoffice.Application.Services.Pessoas.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backoffice.Presentation.API.Controllers;

[Route("api/[controller]")]
public class PessoasController : MainController
{
    private readonly IPessoasService _pessoasService;

    public PessoasController(IPessoasService pessoasService)
    {
        _pessoasService = pessoasService;
    }

    //[Authorize(Roles = "usuario,administrador")]
    [HttpPost("pessoa-fisica")]
    public async Task<IActionResult> CadastrarPessoaFisica(CadastrarPessoaFisicaRequest request)
    {
        var response = await _pessoasService.CadastrarPessoaFisica(request);
        return ApiResult(response);
    }

    //[Authorize(Roles = "usuario,administrador")]
    [HttpPost("pessoa-juridica")]
    public async Task<IActionResult> CadastrarPessoaJuridica(CadastrarPessoaJuridicaRequest request)
    {
        var response = await _pessoasService.CadastrarPessoaJuridica(request);
        return ApiResult(response);
    }

    [Authorize(Roles = "administrador")]
    [HttpGet("pessoas-fisicas")]
    public async Task<IActionResult> BuscarPessoasFisicas()
    {
        var result = await _pessoasService.BuscarPessoasFisicas();
        return ApiResult(result);
    }

    [Authorize(Roles = "administrador")]
    [HttpGet("pessoas-juridicas")]
    public async Task<IActionResult> BuscarPessoasJuridicas()
    {
        var result = await _pessoasService.BuscarPessoasJuridicas();
        return ApiResult(result);
    }

    //[Authorize(Roles = "usuario,administrador")]
    [HttpGet("colaboradores")]
    public async Task<IActionResult> BuscarColaboradores()
    {
        var result = await _pessoasService.BuscarColaboradores();
        return ApiResult(result);
    }
}