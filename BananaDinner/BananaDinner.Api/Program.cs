using BananaDinner.Api.Errors;
using BananaDinner.Api.Filters;
using BananaDinner.Api.Middleware;
using BananaDinner.Application;
using BananaDinner.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
    builder.Services.AddControllers();
    // builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>()); //For all controller add this filter attribute.

    builder.Services.AddSingleton<ProblemDetailsFactory, BananaDinnerProblemDetailsFactory>();
}

var app = builder.Build();
{
    // app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();

    app.Run();
}
