using BananaDinner.Application.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BananaDinner.Api.Controllers;

[Route("/")]
public class ErrorController : ControllerBase
{

    [Route("error")]
    public IActionResult Error()
    {
        // var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        // var (statusCode, message) = exception switch
        // {
        //     IServiceException serviceException => ((int)serviceException.StatusCode, serviceException.ErrorMessage),
        //     _ => (StatusCodes.Status500InternalServerError, "An unexpected error occurred.")
        // };

        return Problem(statusCode: 500, title: "Teste");
    }
}