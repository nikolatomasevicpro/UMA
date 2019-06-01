using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMA.App.IdentityManager.Role.Models;

namespace UMA.App.IdentityManager.Role.Queries
{
    public class GetAllRolesQuery : IRequest<RolesViewModel>
    {
        
    }
}
