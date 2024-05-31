using AuthDemoBlazor.Infrastructure.LookupData;
using AuthDemoBlazor.Infrastructure.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthDemoBlazor.Infrastructure.EntitiesConfiguration
{
    internal class User : IEntityTypeConfiguration<Domain.Entities.User>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.User> builder)
        {
            builder.HasOne(user => user.CreatedBy)
                .WithMany()
                .HasForeignKey("CreatedById")
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(user => user.ModifiedBy)
                .WithMany()
                .HasForeignKey("ModifiedById")
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(SeedData());
        }

        private static IEnumerable<Domain.Entities.User> SeedData()
        {
            Domain.Entities.User systemUser = new()
            {
                Id = 1,
                RoleId = (long)Roles.Administrator,
                IsActive = false,
                UserName = "system",
                EmailConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0
            };

            Domain.Entities.User adminUser = new()
            {
                Id = 2,
                RoleId = (long)Roles.Administrator,
                IsActive = true,
                CreatedById = 1,
                UserName = "adminauthdemo",
                Email = "admin@authdemo.com",
                EmailConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0
            };

            adminUser.Password = new PasswordHasher<Domain.Entities.User>().HashPassword(adminUser, "12345678");

            return new List<Domain.Entities.User>()
            {
                systemUser,
                adminUser
            };
        }

        private static string GetSecurityStamp()
        {
            return SecurityStampGenerator.GenerateSecurityStamp();
        }
    }
}
