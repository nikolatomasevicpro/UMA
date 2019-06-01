using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UMA.App.IdentityManager.Identity.Models;
using UMA.App.IdentityManager.Identity.Queries;
using UMA.Persistence.Identity.Context;

namespace UMA.App.IdentityManager.Identity.Handlers
{
    public class GetAllIdentitiesQueryHandler : IdentityManagerBaseHandler<GetAllIdentitiesQuery, IdentitiesViewModel>
    {
        public GetAllIdentitiesQueryHandler(IdentityDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<IdentitiesViewModel> Handle(GetAllIdentitiesQuery request, CancellationToken cancellationToken)
        {
            var response = new IdentitiesViewModel();
            response.Identities = new List<IdentityViewModel>();

            try
            {
                foreach (var item in await _context.Identities
                    .Include(x => x.IdentityRoles).ThenInclude(x => x.Role)
                    .ToListAsync())
                {
                    response.Identities.Add(_mapper.Map<IdentityViewModel>(item));
                }

                response.Result = true;
                response.Message = $"Found {response.Identities.Count} identit{(response.Identities.Count == 1 ? "y" : "ies")}.";
            }
            catch(Exception e)
            {
                HandleException(response, e);
            }

            return response;
        }
    }
}
