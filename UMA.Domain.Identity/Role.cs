using System;
using System.Collections.Generic;
using UMA.Domain.Common.Interfaces;

namespace UMA.Domain.Identity
{
    public class Role : ITracker
    {
        #region ITRacker

        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        #endregion

        public string Name { get; set; }
        public string Description { get; set; }

        #region Navigation

        public virtual ICollection<IdentityRole> IdentityRoles { get; set; }
        
        #endregion
    }
}
