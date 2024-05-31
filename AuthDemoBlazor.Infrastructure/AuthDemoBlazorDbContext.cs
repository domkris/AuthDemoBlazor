using Microsoft.EntityFrameworkCore;

namespace AuthDemoBlazor.Infrastructure
{
    public class AuthDemoBlazorDbContext : DbContext
    {
        public AuthDemoBlazorDbContext(
            DbContextOptions<AuthDemoBlazorDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
