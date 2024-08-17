using Microsoft.AspNetCore.Mvc;

namespace BananaDinner.Api.Controllers;

[Route("[controller]")]
public class DinnerController : ApiController
{
    [HttpGet]
    public IActionResult ListDinners()
    {
        return Ok(Array.Empty<string>());
    }
}