using CompanyEmployees.Application.Repositories;
using CompanyEmployees.Application.Services;
using CompanyEmployees.Application.Services.Common;
using CompanyEmployees.Infrastructure.Contexts;
using CompanyEmployees.Infrastructure.Repositories;
using CompanyEmployees.Infrastructure.Services;

using LoggerService;

using Microsoft.EntityFrameworkCore;

namespace CompanyEmployees.API.Extensions
{
    internal static class ServiceExtensions
    {
        internal static void ConfigureCORS(this IServiceCollection services, string name)
        {
            services.AddCors(setup =>
            {
                setup.AddPolicy(name, policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyHeader();
                });
            });
        }

        internal static void ConfigureIISIntegration(this IServiceCollection services)
        {
            //more info: https://docs.huihoo.com/dotnet/aspnet/api/1.0.0/autoapi/Microsoft/AspNetCore/Builder/IISOptions/index.html
            services.Configure<IISOptions>(options =>
            {
                //options.AutomaticAuthentication = true;
                //options.AuthenticationDisplayName = null;
                //options.ForwardClientCertificate = true;
            });
        }

        internal static void ConfigureLoggerService(this IServiceCollection services)
            => services.AddSingleton<ILoggerManager, LoggerManager>();

        internal static void ConfigureRepositoryManager(this IServiceCollection services)
            => services.AddScoped<IRepositoryManager, RepositoryManager>();

        internal static void ConfigureServiceManager(this IServiceCollection services)
            => services.AddScoped<IServiceManager, ServiceManager>();

        //internal static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        //    => services.AddDbContext<ApplicationDbContext>(
        //        opts => opts.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        internal static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
            => services.AddSqlServer<ApplicationDbContext>((configuration.GetConnectionString("DefaultConnection")));
    }
}