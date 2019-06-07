using System;
using System.Collections.Generic;
using UMA.Domain.Common.Interfaces;

namespace UMA.Domain.Identity
{
    public class Identity : ITracker
    {
        #region ITracker

        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        #endregion

        public string Login { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }

        #region Navigation

        public Profile Profile { get; set; }
        public virtual ICollection<IdentityRole> IdentityRoles { get; set; }
        
        #endregion
    }
}
