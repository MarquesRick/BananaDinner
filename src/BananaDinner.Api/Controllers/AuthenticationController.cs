using BananaDinner.Application.Services.Authentication;
using BananaDinner.Application.Services.Authentication.Commands;
using BananaDinner.Application.Services.Authentication.Common;
using BananaDinner.Application.Services.Authentication.Queries;
using BananaDinner.Contracts.Authentication;
using BananaDinner.Domain.Common.Errors;
using Microsoft.AspNetCore.Mvc;

namespace BananaDinner.Api.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly IAuthenticationCommandService _authenticationCommandService;
    private readonly IAuthenticationQueryService _authenticationQueryService;

    public AuthenticationController(IAuthenticationCommandService authenticationCommandService, IAuthenticationQueryService authenticationQueryService)
    {
        _authenticationCommandService = authenticationCommandService;
        _authenticationQueryService = authenticationQueryService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var registerResult = _authenticationCommandService.Register(request.FirstName,
                                        request.LastName,
                                        request.Email,
                                        request.Password);

        return registerResult.Match(
            registerResult => Ok(MapAuthResult(registerResult)),
            errors => Problem(errors)
        );
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResult = _authenticationQueryService.Login(
            request.Email,
            request.Password);

        if (authResult.IsError
            && authResult.FirstError == Errors.Authentication.InvalidCredentials)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: authResult.FirstError.Description);
        }
        return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors)
        );
    }

    private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(
                    authResult.User.Id,
                    authResult.User.FirstName,
                    authResult.User.LastName,
                    authResult.User.Email,
                    authResult.Token);
    }

}