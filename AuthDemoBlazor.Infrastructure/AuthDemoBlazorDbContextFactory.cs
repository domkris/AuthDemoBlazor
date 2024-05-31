using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AuthDemoBlazor.Infrastructure
{
    // This is only used for migrations and dotnet ef database update
    // See https://docs.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli#from-a-design-time-factory
    internal class AuthDemoBlazorDbContextFactory : IDesignTimeDbContextFactory<AuthDemoBlazorDbContext>
    {
        public AuthDemoBlazorDbContext CreateDbContext(string[] args) 
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.migrations.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<AuthDemoBlazorDbContext>();

            optionsBuilder.UseSqlServer(
                 configuration.GetConnectionString("Default"),
                     builder => builder.MigrationsAssembly(typeof(AuthDemoBlazorDbContext).Assembly.FullName));

            return new AuthDemoBlazorDbContext(optionsBuilder.Options);
        }
    }
}
