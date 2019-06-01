using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UMA.App.IdentityManager.Identity.Models;
using UMA.App.IdentityManager.Identity.Queries;
using UMA.Persistence.Identity.Context;

namespace UMA.App.IdentityManager.Identity.Handlers
{
    public class GetIdentityQueryHandler : IdentityManagerBaseHandler<GetIdentityQuery, IdentityViewModel>
    {
        public GetIdentityQueryHandler(IdentityDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async override Task<IdentityViewModel> Handle(GetIdentityQuery request, CancellationToken cancellationToken)
        {
            var response = new IdentityViewModel();

            try
            {
                var result = await _context.Identities
                    .Include(x => x.IdentityRoles).ThenInclude(x => x.Role)
                    .ToListAsync().ContinueWith(l => l.Result.FirstOrDefault(x => x.Id == request.Id || x.Login == request.Login));

                if (result == null)
                {
                    response.Result = false;
                    response.Message = @"No identity matches the request parameters";
                }
                else
                {
                    response = _mapper.Map<IdentityViewModel>(result);
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
