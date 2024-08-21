using BananaDinner.Domain.UserAggregate;

namespace BananaDinner.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
