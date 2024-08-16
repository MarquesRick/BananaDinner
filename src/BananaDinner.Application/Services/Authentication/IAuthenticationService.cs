using BananaDinner.Application.Common.Errors;
using OneOf;

namespace BananaDinner.Application.Services.Authentication;

public interface IAuthenticationService
{
    OneOf<AuthenticationResult, IError> Register(string firstName, string lastName, string email, string password);
    AuthenticationResult Login(string email, string password);
}