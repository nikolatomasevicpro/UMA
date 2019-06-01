using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UMA.App.IdentityManager.Identity.Models;
using UMA.App.IdentityManager.Identity.Queries;

namespace UMA.Web.Api.Controllers
{
    public class IdentityController : BaseController
    {
        [HttpGet]
        [Authorize(Policy = "Admin")]
        public Task<IdentitiesViewModel> GetAllIdentities()
        {
            return Mediator.Send(new GetAllIdentitiesQuery());
        }

        [HttpPost]
        [Authorize(Policy = "Admin")]
        public Task<IdentityViewModel> GetIdentity(GetIdentityQuery query)
        {
            return Mediator.Send(query);
        }

        [HttpPost]
        [Authorize(Policy = "Admin")]
        public Task<CreateIdentityResult> CreateIdentity(CreateIdentityQuery query)
        {
            return Mediator.Send(query);
        }

        [HttpPost]
        [Authorize(Policy = "Admin")]
        public Task<UpdateIdentityResult> UpdateIdentity(UpdateIdentityQuery query)
        {
            return Mediator.Send(query);
        }

        [HttpPost]
        [Authorize(Policy = "Admin")]
        public Task<DeleteIdentityResult> DeleteIdentity(DeleteIdentityQuery query)
        {
            return Mediator.Send(query);
        }
    }
}
