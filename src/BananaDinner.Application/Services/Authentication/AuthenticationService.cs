using BananaDinner.Application.Common.Errors;
using BananaDinner.Application.Common.Interfaces.Authentication;
using BananaDinner.Application.Common.Interfaces.Persistence;
using BananaDinner.Domain.Common.Errors;
using BananaDinner.Domain.Entities;
using ErrorOr;
using FluentResults;

namespace BananaDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository = null)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
        //1. validate the user doesn't exist
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        //2. create user (generate unique Id) & persist to db
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email
        };

        _userRepository.Add(user);

        //3. create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user, token);
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