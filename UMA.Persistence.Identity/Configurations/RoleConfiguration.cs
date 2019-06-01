using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UMA.Domain.Identity;

namespace UMA.Persistence.Identity.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable(nameof(Role));
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();
            builder.Property(e => e.Name)
                .HasMaxLength(64)
                .IsRequired()
                .Metadata.IsIndex();
            builder.Property(e => e.Description)
                .HasMaxLength(256);
            builder.HasMany(e => e.IdentityRoles)
                .WithOne(e => e.Role)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
