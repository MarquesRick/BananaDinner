using BananaDinner.Domain.UserAggregate;

namespace BananaDinner.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token);
