using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMA.Domain.Common.Interfaces;

namespace UMA.Domain.Identity
{
    public class Profile : ITracker
    {
        public Guid Id { get; set; }

        public string Locale { get; set; }

        public Guid IdentityId { get; set; }
        public virtual Identity Identity { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
