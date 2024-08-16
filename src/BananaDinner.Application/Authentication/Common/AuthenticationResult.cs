using BananaDinner.Domain.Entities;

namespace BananaDinner.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token
);