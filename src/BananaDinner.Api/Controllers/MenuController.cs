using BananaDinner.Api.Common;
using BananaDinner.Contracts.Menu;
using Microsoft.AspNetCore.Mvc;

namespace BananaDinner.Api.Controllers;

[Route(Routes.Menus.Base)]
public class MenuController : ApiController
{
    [HttpPost]
    public IActionResult CreateMenu(
        CreateMenuRequest request,
        string hostId)
    {
        return Ok(request);
    }
}
