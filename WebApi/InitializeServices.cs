using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace CoreStart.WebApi
{
    internal static class InitializeServices
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            var declarations = Business.Authorize.InitializeServices.Register().ToList();

            foreach (var declaration in declarations)
            {
                services.AddTransient(declaration.DeclarationType, declaration.InstanceType);
            }

            return services;
        }
    }
}