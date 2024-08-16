using BananaDinner.Domain.Entities;

namespace BananaDinner.Application.Services.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token
);