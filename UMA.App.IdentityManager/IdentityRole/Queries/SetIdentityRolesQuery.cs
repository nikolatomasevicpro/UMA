using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMA.App.IdentityManager.IdentityRole.Models;

namespace UMA.App.IdentityManager.IdentityRole.Queries
{
    public class SetIdentityRolesQuery : IRequest<SetIdentityRolesResult>
    {
        public Guid Identity { get; set; }
        public List<Guid> Roles { get; set; }
    }
}
