using System;
using UMA.Domain.Common.Interfaces;

namespace UMA.Domain.Identity
{
    public class IdentityRole : ITracker
    {
        #region ITracker

        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        
        #endregion

        public Guid IdentityId { get; set; }
        public virtual Identity Identity { get; set; }
        public Guid RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
