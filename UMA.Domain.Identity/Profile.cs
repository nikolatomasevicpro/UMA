using System;
using UMA.Domain.Common.Interfaces;

namespace UMA.Domain.Identity
{
    public class Profile : ITracker
    {
        #region ITracker

        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        
        #endregion

        public string Locale { get; set; }

        #region Navigation

        public Guid IdentityId { get; set; }
        public virtual Identity Identity { get; set; }

        #endregion
    }
}
