using Backoffice.Application.Services.Base;
using Microsoft.AspNetCore.Mvc;

namespace Backoffice.Presentation.API.Controllers;

[ApiController]
public abstract class MainController : ControllerBase
{
    protected IActionResult ApiResult(BaseResponse response)
    {
        if (response.Success)
        {
            return Ok(response);
        }

        return BadRequest(response);
    }

    protected IActionResult ApiResult<T>(BaseResponse<T> response)
    {
        if (response.Success)
        {
            return Ok(response);
        }

        return BadRequest(response);
    }
}