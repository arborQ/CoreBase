using System.Linq;
using Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoreStart.WebApi
{
    internal static class InitializeServices
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            var declarations = Business.Authorize.InitializeServices.Register().ToList();

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