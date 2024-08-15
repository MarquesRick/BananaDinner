using BananaDinner.Application.Common.Interfaces.Authentication;
using BananaDinner.Infrastructure.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace BananaDinner.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        return services;
    }
}
