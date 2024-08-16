using BananaDinner.Application.Common.Interfaces.Authentication;
using BananaDinner.Application.Common.Interfaces.Persistence;
using BananaDinner.Application.Services.Authentication.Common;
using BananaDinner.Domain.Common.Errors;
using BananaDinner.Domain.Entities;
using ErrorOr;

namespace BananaDinner.Application.Services.Authentication.Queries;

public class AuthenticationQueryService : IAuthenticationQueryService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationQueryService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository = null)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {
        //1. validate the user exists
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        //2. validate then password is correct
        if (user.Password != password)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        //3. create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}