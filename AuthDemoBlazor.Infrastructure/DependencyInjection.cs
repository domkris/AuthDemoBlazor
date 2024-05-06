using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuthDemoBlazor.Infrastructure
{
    public static class DependencyInjection
    {
        public static void RegisterInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AuthDemoBlazorDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("Default")));
        }
    }
}
