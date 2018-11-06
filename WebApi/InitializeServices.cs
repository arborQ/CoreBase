using System.Linq;
using System.Reflection;
using Data.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Structure.Services;
using WebApi.Services;

namespace CoreStart.WebApi
{
    internal static class InitializeServices
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            var declarations = Business.Authorize.InitializeServices.Register()
                .Concat(Business.Account.InitializeServices.Register())
                .ToList();

            services.AddSingleton<ICryptography, CryptographyService>();
            services.AddMediatR(typeof(Business.Authorize.InitializeServices).GetTypeInfo().Assembly, typeof(InitializeServices).GetTypeInfo().Assembly);

            foreach (var declaration in declarations)
            {
                services.AddTransient(declaration.DeclarationType, declaration.InstanceType);
            }

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                string conString =
                       ConfigurationExtensions
                       .GetConnectionString(configuration, "DefaultConnection");

                options.UseSqlServer(conString);
            }, ServiceLifetime.Scoped);

            return services;
        }
    }
}