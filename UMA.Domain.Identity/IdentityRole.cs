using System;
using UMA.Domain.Common.Interfaces;

namespace UMA.Domain.Identity
{
    public class IdentityRole : ITracker
    {
        public Guid Id { get; set; }
        public Guid IdentityId { get; set; }
        public virtual Identity Identity { get; set; }
        public Guid RoleId { get; set; }
        public virtual Role Role { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
