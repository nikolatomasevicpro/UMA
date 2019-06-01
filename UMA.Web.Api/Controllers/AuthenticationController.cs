using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using UMA.App.IdentityManager.Authentication.Models;
using UMA.App.IdentityManager.Authentication.Queries;

namespace UMA.Web.Api.Controllers
{
    public class AuthenticationController : BaseController
    {
        [AllowAnonymous]
        public Task<AuthenticateUserResult> Authenticate(AuthenticateUserQuery query)
        {
            return Mediator.Send(query);
        }

        [AllowAnonymous]
        public Task<RegisterUserResult> Register(RegisterUserQuery query)
        {
            return Mediator.Send(query);
        }
    }
}
