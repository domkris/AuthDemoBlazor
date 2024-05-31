using AuthDemoBlazor.Infrastructure.LookupData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthDemoBlazor.Infrastructure.EntitiesConfiguration
{
    internal sealed class Role : IEntityTypeConfiguration<Domain.Entities.Role>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Role> builder)
        {
            builder.HasIndex(entity => entity.Name).IsUnique();
            builder.Property(entity => entity.Name).IsRequired();
            builder.HasMany(entity => entity.Users)
                .WithOne(entity => entity.Role);
            builder.HasData(SeedData());
        }

        private static IEnumerable<Domain.Entities.Role> SeedData()
        {
            return Enum.GetValues(typeof(Roles))
                .OfType<Roles>()
                .Select(role => new Domain.Entities.Role
                { 
                    Id = (long) role,
                    Name = role.ToString()
                });
        }
    }
}
