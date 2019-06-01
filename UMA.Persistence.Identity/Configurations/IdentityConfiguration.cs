using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UMA.Persistence.Identity.Configurations
{
    public class IdentityConfiguration : IEntityTypeConfiguration<Domain.Identity.Identity>
    {
        public void Configure(EntityTypeBuilder<Domain.Identity.Identity> builder)
        {
            builder.ToTable(nameof(Domain.Identity.Identity));
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();
            builder.Property(e => e.Login)
                .HasMaxLength(64)
                .IsRequired()
                .Metadata.IsIndex();
            builder.Property(e => e.Password)
                .HasMaxLength(1024)
                .IsRequired();
            builder.Property(e => e.Salt)
                .IsRequired();
            builder.HasOne(e => e.Profile)
                .WithOne(e => e.Identity)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(e => e.IdentityRoles)
                .WithOne(e => e.Identity)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
