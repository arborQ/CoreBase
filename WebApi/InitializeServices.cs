using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi {
    internal static class InitializeServices {
        public static void RegisterServices (IServiceCollection services) {
            // var builder = new ContainerBuilder ();

            // var declarations = Business.Authorize.InitializeServices.Register ().ToList ();

            // foreach (var declaration in declarations) {
            //     builder.RegisterType (declaration.DeclarationType).As (declaration.InstanceType).InstancePerDependency ();
            // }

            // builder.Populate (services);

            // var container = builder.Build ();
        }
    }
}