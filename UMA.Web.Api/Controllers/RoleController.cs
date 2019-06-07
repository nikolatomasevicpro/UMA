using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UMA.App.IdentityManager.Role.Models;
using UMA.App.IdentityManager.Role.Queries;

namespace UMA.Web.Api.Controllers
{
    public class RoleController : BaseController
    {
        [HttpGet]
        [Authorize(Policy = "Admin")]
        public Task<RolesViewModel> GetAllRoles()
        {
            return Mediator.Send(new GetAllRolesQuery());
        }

        [HttpPost]
        [Authorize(Policy = "Admin")]
        public Task<RoleViewModel> GetRole(GetRoleQuery query)
        {
            return Mediator.Send(query);
        }

        [HttpPost]
        [Authorize(Policy = "Admin")]
        public Task<RolesViewModel> GetRolesByIdentity(GetRolesByIdentityQuery query)
        {
            return Mediator.Send(query);
        }

        [HttpPost]
        [Authorize(Policy = "Admin")]
        public Task<CreateRoleResult> CreateRole(CreateRoleQuery query)
        {
            return Mediator.Send(query);
        }

        [HttpPost]
        [Authorize(Policy = "Admin")]
        public Task<UpdateRoleResult> UpdateRole(UpdateRoleQuery query)
        {
            return Mediator.Send(query);
        }

        [HttpPost]
        [Authorize(Policy = "Admin")]
        public Task<DeleteRoleResult> DeleteRole(DeleteRoleQuery query)
        {
            return Mediator.Send(query);
        }
    }
}
