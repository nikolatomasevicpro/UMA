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
    public class GetAllRolesQueryHandler : IdentityManagerBaseHandler<GetAllRolesQuery, RolesViewModel>
    {
        public GetAllRolesQueryHandler(IdentityDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async override Task<RolesViewModel> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            var response = new RolesViewModel();
            response.Roles = new List<RoleViewModel>();

            try
            {
                foreach (var item in await _context.Roles
                    .Include(x => x.IdentityRoles).ThenInclude(x => x.Identity)
                    .ToListAsync())
                {
                    response.Roles.Add(_mapper.Map<RoleViewModel>(item));
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
