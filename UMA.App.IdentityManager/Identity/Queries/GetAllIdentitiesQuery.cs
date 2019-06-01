using MediatR;
using UMA.App.IdentityManager.Identity.Models;

namespace UMA.App.IdentityManager.Identity.Queries
{
    public class GetAllIdentitiesQuery : IRequest<IdentitiesViewModel>
    {
    }
}
