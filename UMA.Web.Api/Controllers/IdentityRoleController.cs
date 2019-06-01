using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UMA.App.IdentityManager.IdentityRole.Models;
using UMA.App.IdentityManager.IdentityRole.Queries;

namespace UMA.Web.Api.Controllers
{
    public class IdentityRoleController : BaseController
    {
        [HttpPost]
        [Authorize(Policy = "Admin")]
        public Task<CreateIdentityRoleResult> CreateRole(CreateIdentityRoleQuery query)
        {
            return Mediator.Send(query);
        }

        [HttpPost]
        [Authorize(Policy = "Admin")]
        public Task<DeleteIdentityRoleResult> DeleteRole(DeleteIdentityRoleQuery query)
        {
            return Mediator.Send(query);
        }

        [HttpPost]
        [Authorize(Policy = "Admin")]
        public Task<SetIdentityRolesResult> SetRoles(SetIdentityRolesQuery query)
        {
            return Mediator.Send(query);
        }
    }
}
