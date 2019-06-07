using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UMA.App.IdentityManager.Profile.Models;
using UMA.App.IdentityManager.Profile.Queries;
using UMA.Persistence.Identity.Context;

namespace UMA.App.IdentityManager.Profile.Handlers
{
    public class GetProfileQueryHandler : IdentityManagerBaseHandler<GetProfileQuery, ProfileViewModel>
    {
        public GetProfileQueryHandler(IdentityDbContext context, IMapper mapper, IMediator mediatr) : base(context, mapper)
        {
        }

        public async override Task<ProfileViewModel> Handle(GetProfileQuery request, CancellationToken cancellationToken)
        {
            var response = new ProfileViewModel();

            try
            {
                var list = _context.Profiles.AsQueryable();

                if (request.Id.HasValue)
                {
                    list = list.Where(e => e.Id == request.Id.Value);
                }

                if(request.IdentityId.HasValue)
                {
                    list = list.Where(e => e.IdentityId == request.IdentityId.Value);
                }

                var profile = await list.FirstOrDefaultAsync();
                if (profile != null)
                {
                    response = _mapper.Map<ProfileViewModel>(profile);
                    response.Result = true;
                    response.Message = @"Match found";
                }
                else
                {
                    response.Result = false;
                    response.Message = $"No profile matches the request parameters";
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
