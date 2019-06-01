using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using UMA.App.IdentityManager.Identity.Models;
using UMA.App.IdentityManager.Identity.Queries;
using UMA.Persistence.Identity.Context;

namespace UMA.App.IdentityManager.Identity.Handlers
{
    public class DeleteIdentityQueryHandler : IdentityManagerBaseHandler<DeleteIdentityQuery, DeleteIdentityResult>
    {
        public DeleteIdentityQueryHandler(IdentityDbContext context, IMapper mapper, IMediator mediator) : base(context, mapper)
        {
        }

        public async override Task<DeleteIdentityResult> Handle(DeleteIdentityQuery request, CancellationToken cancellationToken)
        {
            var response = new DeleteIdentityResult();

            try
            {
                var entity = await _context.Identities.Include(x => x.IdentityRoles).FirstOrDefaultAsync(e => e.Id == request.Id);

                if(entity == null)
                {
                    response.Result = false;
                    response.Message = $"No match found for the id \"{request.Id}\"";
                }
                else
                {
                    _context.Identities.Remove(entity);
                    await _context.SaveChangesAsync();
                    response.Result = true;
                    response.Message = $"The identity with the id \"{request.Id}\" has been removed";
                }
            }
            catch (Exception e)
            {
                HandleException(response, e);
            }

            return response;
        }
    }
}
