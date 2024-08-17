using BananaDinner.Api.Common.Errors;
using BananaDinner.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BananaDinner.Api;
public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, BananaDinnerProblemDetailsFactory>();
        services.AddMappings();
        return services;
    }
}
