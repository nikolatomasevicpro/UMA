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
    public class UpdateRoleQueryHandler : IdentityManagerBaseHandler<UpdateRoleQuery, UpdateRoleResult>
    {
        public UpdateRoleQueryHandler(IdentityDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async override Task<UpdateRoleResult> Handle(UpdateRoleQuery request, CancellationToken cancellationToken)
        {
            var response = new UpdateRoleResult();

            try
            {
                var entity = await _context.Roles.FirstOrDefaultAsync(x => x.Id == request.Id);

                if (entity == null)
                {
                    response.Result = false;
                    response.Message = $"Role with id \"{request.Id}\" not found";
                }
                else
                {
                    if (!string.IsNullOrEmpty(request.Name))
                    {
                        entity.Name = request.Name;
                    }

                    if (!string.IsNullOrEmpty(request.Description))
                    {
                        entity.Description = request.Description;
                    }

                    _context.Update(entity);
                    await _context.SaveChangesAsync();

                    response.Result = true;
                    response.Message = $"Entity \"{entity.Name}\" updated";
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
