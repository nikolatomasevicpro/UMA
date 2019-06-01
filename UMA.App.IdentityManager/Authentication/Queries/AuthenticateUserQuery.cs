using MediatR;
using UMA.App.IdentityManager.Authentication.Models;

namespace UMA.App.IdentityManager.Authentication.Queries
{
    public class AuthenticateUserQuery : BaseIdentityQuery, IRequest<AuthenticateUserResult>
    {
    }
}
