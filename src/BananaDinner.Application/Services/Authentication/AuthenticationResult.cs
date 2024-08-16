using BananaDinner.Domain.Entities;

namespace BananaDinner.Application.Services.Authentication;

public record AuthenticationResult(
    User User,
    string Token
);