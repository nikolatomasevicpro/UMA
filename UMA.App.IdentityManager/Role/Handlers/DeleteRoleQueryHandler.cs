using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using UMA.App.IdentityManager.Role.Models;
using UMA.App.IdentityManager.Role.Queries;
using UMA.Persistence.Identity.Context;

namespace UMA.App.IdentityManager.Role.Handlers
{
    public class DeleteRoleQueryHandler : IdentityManagerBaseHandler<DeleteRoleQuery, DeleteRoleResult>
    {
        public DeleteRoleQueryHandler(IdentityDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async override Task<DeleteRoleResult> Handle(DeleteRoleQuery request, CancellationToken cancellationToken)
        {
            var response = new DeleteRoleResult();

            try
            {
                var entity = await _context.Roles.Include(x => x.IdentityRoles).FirstOrDefaultAsync(e => e.Id == request.Id);

                if (entity == null)
                {
                    response.Result = false;
                    response.Message = $"No math found for the id \"{request.Id}\"";
                }
                else
                {
                    if (entity.IdentityRoles.Count > 0)
                    {
                        foreach (var IdentityRole in entity.IdentityRoles)
                        {
                            _context.IdentityRoles.Remove(IdentityRole);
                        }
                    }

                    _context.Roles.Remove(entity);

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
