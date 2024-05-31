using AuthDemoBlazor.Application.Services;
using AuthDemoBlazor.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AuthDemoBlazor.Application
{
    public static class DependencyInjection
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScopedServices(typeof(IUnitOfWork).Assembly, typeof(DependencyInjection).Assembly);
        }
    }


    public static class DependencyInjectionExtensions
    {

        public static void AddScopedServices(
            this IServiceCollection services,
            Assembly interfacesAssembly,
            Assembly interfacesImplementationAssembly)
        {
            var serviceInterfaces = interfacesAssembly.GetTypes()
               .Where(type => type.FullName!.EndsWith("Service"))
               .ToList();

            foreach (var serviceInterface in serviceInterfaces)
            {
                var serviceImplementation = interfacesImplementationAssembly.GetTypes()
                    .FirstOrDefault(type => serviceInterface.IsAssignableFrom(type) && !type.IsInterface);

                if (serviceImplementation != null)
                {
                    services.AddScoped(serviceInterface, serviceImplementation);
                }
            }
        }
    }
}
