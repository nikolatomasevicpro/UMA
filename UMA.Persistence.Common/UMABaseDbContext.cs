using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMA.Persistence.Common
{
    public class UMABaseDbContext<T> : DbContext where T : DbContext
    {
        public UMABaseDbContext(DbContextOptions<T> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(T).Assembly);
        }
    }
}
