using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UMA.App.IdentityManager.Profile.Models;
using UMA.App.IdentityManager.Profile.Queries;

namespace UMA.Web.Api.Controllers
{
    public class ProfileController : BaseController
    {
        [HttpPost]
        [Authorize(Policy = "Admin")]
        public Task<ProfileViewModel> GetProfile(GetProfileQuery query)
        {
            return Mediator.Send(query);
        }

        [HttpPost]
        [Authorize(Policy = "Admin")]
        public Task<UpdateProfileResult> UpdateProfile(UpdateProfileQuery query)
        {
            return Mediator.Send(query);
        }
    }
}
