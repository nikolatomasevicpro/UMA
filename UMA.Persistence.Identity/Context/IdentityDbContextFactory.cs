using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMA.Persistence.Common;

namespace UMA.Persistence.Identity.Context
{
    public class IdentityDbContextFactory : DesignTimeDbContextFactoryBase<IdentityDbContext>
    {
        public IdentityDbContextFactory() : base("IdentityConnection", "UMA")
        {
        }

        protected override IdentityDbContext CreateNewInstance(DbContextOptions<IdentityDbContext> options)
        {
            return new IdentityDbContext(options);
        }
    }
}
