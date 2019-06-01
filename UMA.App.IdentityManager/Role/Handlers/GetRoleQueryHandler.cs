using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UMA.App.IdentityManager.Role.Models;
using UMA.App.IdentityManager.Role.Queries;
using UMA.Persistence.Identity.Context;

namespace UMA.App.IdentityManager.Role.Handlers
{
    public class GetRoleQueryHandler : IdentityManagerBaseHandler<GetRoleQuery, RoleViewModel>
    {
        public GetRoleQueryHandler(IdentityDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async override Task<RoleViewModel> Handle(GetRoleQuery request, CancellationToken cancellationToken)
        {
            var response = new RoleViewModel();

            try
            {
                var result = await _context.Roles
                    .Include(x => x.IdentityRoles).ThenInclude(x => x.Identity)
                    .ToListAsync().ContinueWith(l => l.Result.FirstOrDefault(x => x.Id == request.Id || x.Name == request.Name || x.Description == request.Description));

                if (result == null)
                {
                    response.Result = false;
                    response.Message = @"No role matches the request parameters";
                }
                else
                {
                    response = _mapper.Map<RoleViewModel>(result);
                    response.Result = true;
                    response.Message = @"Match found";
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
