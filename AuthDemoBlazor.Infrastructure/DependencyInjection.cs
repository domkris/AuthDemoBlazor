using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using AuthDemoBlazor.Domain.Interfaces;
using AuthDemoBlazor.Application;

namespace AuthDemoBlazor.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddServices(configuration);

            services.AddSecurity(configuration);
            services.AddPersistence(configuration);

        }

        private static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AuthDemoBlazorDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Default")));

        }

        private static void AddSecurity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(configuration);
            //services.AddAuthorization();
        }

        private static void AddAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
             .AddCookie(options =>
             {
                 options.Cookie.Name = "authdemoblazor_token";
                 options.LoginPath = new PathString("/Login");
                 options.Cookie.MaxAge = TimeSpan.FromMinutes(15);
                 options.AccessDeniedPath = new PathString("/Access-Denied");
             });

        }

        private static void AddAuthorization(this IServiceCollection services)
        {
        }
    }
}
