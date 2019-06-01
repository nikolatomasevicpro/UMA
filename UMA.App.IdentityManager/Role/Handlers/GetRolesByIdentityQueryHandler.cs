using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UMA.App.IdentityManager.Role.Models;
using UMA.App.IdentityManager.Role.Queries;
using UMA.Persistence.Identity.Context;

namespace UMA.App.IdentityManager.Role.Handlers
{
    public class GetRolesByIdentityQueryHandler : IdentityManagerBaseHandler<GetRolesByIdentityQuery, RolesViewModel>
    {
        public GetRolesByIdentityQueryHandler(IdentityDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async override Task<RolesViewModel> Handle(GetRolesByIdentityQuery request, CancellationToken cancellationToken)
        {
            var response = new RolesViewModel();
            response.Roles = new List<RoleViewModel>();

            try
            {
                var identity = await _context.Identities
                    .Include(e => e.IdentityRoles).ThenInclude(e => e.Role)
                    .FirstOrDefaultAsync(e => e.Id == request.Id);

                if (identity != null)
                {
                    foreach (var item in identity.IdentityRoles)
                    {
                        response.Roles.Add(_mapper.Map<RoleViewModel>(item.Role));
                    }
                }

                response.Result = true;
                response.Message = $"Found {response.Roles.Count} role{(response.Roles.Count == 1 ? "" : "s")}.";
            }
            catch (Exception e)
            {
                HandleException(response, e);
            }

            return response;
        }

    }
}
