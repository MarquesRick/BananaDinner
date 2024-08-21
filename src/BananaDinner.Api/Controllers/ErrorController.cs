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
        return Problem(statusCode: 500, title: "An unexpected error occurred");
    }
}
