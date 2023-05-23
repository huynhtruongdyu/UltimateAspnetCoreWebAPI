using CompanyEmployees.API.Extensions;
using CompanyEmployees.API.Shared.Constants;
using CompanyEmployees.Application.Services.Common;

using Microsoft.AspNetCore.HttpOverrides;

using NLog;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var environment = builder.Environment;

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

#region Add services to the container.

builder.Services.ConfigureCORS(DefaultConstants.CORS_POLICY);
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.AddAutoMapper(typeof(CompanyEmployees.Application.AssemblyReference));
builder.Services.AddControllers();

#endregion Add services to the container.

builder.Services.AddControllers()
    .AddApplicationPart(typeof(CompanyEmployees.Presentation.AssemblyReference).Assembly); ;

var app = builder.Build();
{
    var logger = app.Services.GetRequiredService<ILoggerManager>();
    app.ConfigureExceptionHandler(logger);
    if (environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
    else
    {
        app.UseHsts();
    }
    app.UseHttpsRedirection();

    app.UseStaticFiles();
    app.UseForwardedHeaders(new ForwardedHeadersOptions
    {
        ForwardedHeaders = ForwardedHeaders.All
    });
    app.UseCors(DefaultConstants.CORS_POLICY);

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}