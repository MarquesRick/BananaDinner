using BananaDinner.Domain.UserAggregate;

namespace BananaDinner.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}
