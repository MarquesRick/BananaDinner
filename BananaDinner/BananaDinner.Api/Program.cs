using BananaDinner.Api.Filters;
using BananaDinner.Api.Middleware;
using BananaDinner.Application;
using BananaDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
    builder.Services.AddControllers(options =>
        options.Filters.Add<ErrorHandlingFilterAttribute>()); //For all controller add this filter attribute.
}

var app = builder.Build();
{
    // app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseHttpsRedirection();
    app.MapControllers();

    app.Run();
}
