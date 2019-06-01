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
    public class CreateIdentityRoleQueryHandler : IdentityManagerBaseHandler<CreateIdentityRoleQuery, CreateIdentityRoleResult>
    {
        public CreateIdentityRoleQueryHandler(IdentityDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async override Task<CreateIdentityRoleResult> Handle(CreateIdentityRoleQuery request, CancellationToken cancellationToken)
        {
            var response = new CreateIdentityRoleResult();

            try
            {
                var IdentityRole = await _context.IdentityRoles
                    .Include(x => x.Role)
                    .Include(x => x.Identity)
                    .FirstOrDefaultAsync(e => e.Role.Id == request.Role && e.Identity.Id == request.Identity);

                if (IdentityRole == null)
                {
                    var identity = await _context.Identities.FirstOrDefaultAsync(x => x.Id == request.Identity);

                    if (identity != null)
                    {
                        var role = await _context.Roles.FirstOrDefaultAsync(x => x.Id == request.Role);

                        if (role != null)
                        {
                            var operationResult = await _context.AddAsync(new Domain.Identity.IdentityRole
                            {
                                Role = role,
                                Identity = identity
                            });

                            if (operationResult.IsKeySet)
                            {
                                response.Id = operationResult.Entity.Id;
                                await _context.SaveChangesAsync(cancellationToken);

                                response.Result = true;
                                response.Message = $"IdentityRole for \"{identity.Login}\" created";
                            }
                        }
                        else
                        {
                            response.Result = false;
                            response.Message = $"Role not found";
                        }
                    }
                    else
                    {
                        response.Result = false;
                        response.Message = $"User not found";
                    }
                }
                else
                {
                    response.Result = false;
                    response.Message = $"The user {IdentityRole.Identity.Login} already has the role {IdentityRole.Role.Name}";
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
