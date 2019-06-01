using AutoMapper;
using MediatR;
using UMA.App.Common.MediatR;
using UMA.Persistence.Identity.Context;

namespace UMA.App.IdentityManager
{
    public abstract class IdentityManagerBaseHandler<TRequest, TResponse> : BaseQueryHandler<TRequest, TResponse, IdentityDbContext>
       where TRequest : IRequest<TResponse>
    {
        public IdentityManagerBaseHandler(IdentityDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
