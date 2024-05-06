using AuthDemoBlazor.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthDemoBlazor.Infrastructure
{
    public class AuthDemoBlazorDbContext : IdentityDbContext<User, Role, long>
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
