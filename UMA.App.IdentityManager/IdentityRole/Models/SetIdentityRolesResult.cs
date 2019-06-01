using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMA.App.Common.MediatR;

namespace UMA.App.IdentityManager.IdentityRole.Models
{
    public class SetIdentityRolesResult : BaseViewModel
    {
        public IEnumerable<Guid> Success { get; set; }
        public IEnumerable<Guid> Fail { get; set; }
    }
}
