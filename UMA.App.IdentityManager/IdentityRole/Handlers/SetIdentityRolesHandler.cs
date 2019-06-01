using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UMA.App.IdentityManager.IdentityRole.Models;
using UMA.App.IdentityManager.IdentityRole.Queries;
using UMA.Persistence.Identity.Context;

namespace UMA.App.IdentityManager.IdentityRole.Handlers
{
    public class SetIdentityRolesHandler : IdentityManagerBaseHandler<SetIdentityRolesQuery, SetIdentityRolesResult>
    {
        public SetIdentityRolesHandler(IdentityDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async override Task<SetIdentityRolesResult> Handle(SetIdentityRolesQuery request, CancellationToken cancellationToken)
        {
            var response = new SetIdentityRolesResult();
            var success = new List<Guid>();
            var fail = new List<Guid>();

            try
            {
                var identity = await _context.Identities
                    .Include(e => e.IdentityRoles).ThenInclude(e => e.Role)
                    .FirstOrDefaultAsync(e => e.Id == request.Identity);

                if (identity != null)
                {
                    //If there are roles, do a cross reference
                    //To add only the missing, and remove the superfluous
                    if (identity.IdentityRoles.Count > 0)
                    {
                        foreach (var item in identity.IdentityRoles)
                        {
                            //If role is in the list
                            //Keep it, but remove from the list
                            if (request.Roles.Contains(item.Role.Id))
                            {
                                request.Roles.Remove(item.Role.Id);
                                success.Add(item.Role.Id);
                            }
                            else
                            {
                                //Not in the list
                                //Need to remove it from identity
                                _context.IdentityRoles.Remove(item);
                            }
                        }
                    }

                    //Add what is left in the roles list to add
                    foreach (var item in request.Roles)
                    {
                        //Search for the role with id
                        var role = await _context.Roles.FirstOrDefaultAsync(e => e.Id == item);

                        if (role == null)
                        {
                            //No roles found
                            //Add role id to fail list
                            fail.Add(item);
                        }
                        else
                        {
                            //Add role/identity pair
                            var operationResult = await _context.AddAsync(new Domain.Identity.IdentityRole
                            {
                                Role = role,
                                Identity = identity
                            });

                            //Add role id to success list
                            if (operationResult.IsKeySet)
                            {
                                success.Add(operationResult.Entity.Id);
                            }
                        }
                    }

                    await _context.SaveChangesAsync(cancellationToken);

                    response.Result = true;
                    response.Message = $"Roles for \"{identity.Login}\" set";
                    response.Fail = fail;
                    response.Success = success;
                }
                else
                {
                    response.Result = false;
                    response.Message = "User not found";
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
