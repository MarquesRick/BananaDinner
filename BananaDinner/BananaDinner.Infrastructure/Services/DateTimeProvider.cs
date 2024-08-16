using BananaDinner.Application.Common.Interfaces.Services;

namespace BananaDinner.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
