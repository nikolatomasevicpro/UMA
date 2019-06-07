using Microsoft.EntityFrameworkCore;
using System;
using UMA.Domain.Common.Interfaces;
using UMA.Domain.Identity;

namespace UMA.Persistence.Identity.Context
{
    public class IdentityDbContext : DbContext
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
        {
            ChangeTracker.Tracked += ChangeTracker_Tracked;
            ChangeTracker.StateChanged += ChangeTracker_StateChanged;
        }

        private void ChangeTracker_StateChanged(object sender, Microsoft.EntityFrameworkCore.ChangeTracking.EntityStateChangedEventArgs e)
        {
            if (e.NewState == EntityState.Modified && e.Entry.Entity is ITracker entity)
                entity.ModifiedDate = DateTime.UtcNow;
        }

        private void ChangeTracker_Tracked(object sender, Microsoft.EntityFrameworkCore.ChangeTracking.EntityTrackedEventArgs e)
        {
            if (!e.FromQuery && e.Entry.State == EntityState.Added && e.Entry.Entity is ITracker entity)
                entity.CreatedDate = DateTime.UtcNow;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IdentityDbContext).Assembly);
        }

        #region Sets

        public DbSet<Domain.Identity.Identity> Identities { get; set; }
        public DbSet<IdentityRole> IdentityRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        
        #endregion
    }
}
