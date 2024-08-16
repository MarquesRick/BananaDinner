using BananaDinner.Api.Common.Errors;
using BananaDinner.Application;
using BananaDinner.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
    builder.Services.AddControllers();
    //First approach is handling error by filter 
    // builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>()); //For all controller add this filter attribute.

    //Third approach is change the ProblemDetailsFactory from .Net MVC
    builder.Services.AddSingleton<ProblemDetailsFactory, BananaDinnerProblemDetailsFactory>();
}

var app = builder.Build();
{
    //Second approach is handling error over middleware
    // app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();

    app.Run();
}
