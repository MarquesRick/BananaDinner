using BananaDinner.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace BananaDinner.Application.Authentication.Queries.Login;

public record LoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;
