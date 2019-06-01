using System;
using System.Collections.Generic;
using UMA.Domain.Common.Interfaces;

namespace UMA.Domain.Identity
{
    public class Identity : ITracker
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public virtual ICollection<IdentityRole> IdentityRoles { get; set; }
        public Profile Profile { get; set; }
    }
}
