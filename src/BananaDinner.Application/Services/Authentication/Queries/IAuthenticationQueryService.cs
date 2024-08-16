using BananaDinner.Application.Services.Authentication.Common;
using ErrorOr;

namespace BananaDinner.Application.Services.Authentication.Queries;

public interface IAuthenticationQueryService
{
    ErrorOr<AuthenticationResult> Login(string email, string password);
}