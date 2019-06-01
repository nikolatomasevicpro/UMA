using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMA.App.IdentityManager.Role.Models;

namespace UMA.App.IdentityManager.Role.Queries
{
    public class GetRoleQuery : IRequest<RoleViewModel>
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
