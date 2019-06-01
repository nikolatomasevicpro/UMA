using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace UMA.App.Common.MediatR
{
    public abstract class BaseQueryHandler<TRequest, TResponse, TDbContext> : IRequestHandler<TRequest, TResponse>
       where TRequest : IRequest<TResponse>
       where TDbContext : DbContext
    {
        protected readonly TDbContext _context;
        protected readonly IMapper _mapper;

        public BaseQueryHandler(TDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);

        public virtual void HandleException(BaseViewModel viewModel, Exception exception)
        {
            viewModel.Result = false;
            viewModel.Message = $"{GetType().Name} threw an exption with the following message : {exception.Message}";
        }
    }
}
