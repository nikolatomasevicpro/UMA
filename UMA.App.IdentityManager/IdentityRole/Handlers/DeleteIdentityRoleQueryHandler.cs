using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using UMA.App.IdentityManager.IdentityRole.Models;
using UMA.App.IdentityManager.IdentityRole.Queries;
using UMA.Persistence.Identity.Context;

namespace UMA.App.IdentityManager.IdentityRole.Handlers
{
    public class DeleteIdentityRoleQueryHandler : IdentityManagerBaseHandler<DeleteIdentityRoleQuery, DeleteIdentityRoleResult>
    {
        public DeleteIdentityRoleQueryHandler(IdentityDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async override Task<DeleteIdentityRoleResult> Handle(DeleteIdentityRoleQuery request, CancellationToken cancellationToken)
        {
            var response = new DeleteIdentityRoleResult();

            try
            {
                var entity = await _context.IdentityRoles.FirstOrDefaultAsync(e => e.Id == request.Id);

                if (entity == null)
                {
                    response.Result = false;
                    response.Message = $"No match found for the id \"{request.Id}\"";
                }
                else
                {
                    _context.IdentityRoles.Remove(entity);
                    await _context.SaveChangesAsync();
                    response.Result = true;
                    response.Message = $"The role was removed for the user";
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
