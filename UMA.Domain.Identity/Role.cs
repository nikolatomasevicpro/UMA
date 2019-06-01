using System;
using System.Collections.Generic;
using UMA.Domain.Common.Interfaces;

namespace UMA.Domain.Identity
{
    public class Role : ITracker
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<IdentityRole> IdentityRoles { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
