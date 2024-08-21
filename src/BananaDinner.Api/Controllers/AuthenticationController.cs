using BananaDinner.Api.Common;
using BananaDinner.Application.Authentication.Commands.Register;
using BananaDinner.Application.Authentication.Common;
using BananaDinner.Application.Authentication.Queries.Login;
using BananaDinner.Contracts.Authentication;
using BananaDinner.Domain.Common.Errors;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BananaDinner.Api.Controllers;

[AllowAnonymous]
[Route(Routes.Auth.Base)]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public AuthenticationController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost(Routes.Auth.Register)]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
        var registerResult = await _mediator.Send(command);

        return registerResult.Match(
            registerResult => Ok(_mapper.Map<AuthenticationResult>(registerResult)),
            errors => Problem(errors));
    }

    [HttpPost(Routes.Auth.Login)]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = _mapper.Map<LoginQuery>(request);
        var authResult = await _mediator.Send(query);

        if (authResult.IsError
            && authResult.FirstError == Errors.Authentication.InvalidCredentials)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: authResult.FirstError.Description);
        }

        return authResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResult>(authResult)),
            errors => Problem(errors));
    }
}
