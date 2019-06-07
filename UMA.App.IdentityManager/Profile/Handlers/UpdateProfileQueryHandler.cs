using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using UMA.App.IdentityManager.Profile.Models;
using UMA.App.IdentityManager.Profile.Queries;
using UMA.Persistence.Identity.Context;

namespace UMA.App.IdentityManager.Profile.Handlers
{
    public class UpdateProfileQueryHandler : IdentityManagerBaseHandler<UpdateProfileQuery, UpdateProfileResult>
    {
        public UpdateProfileQueryHandler(IdentityDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async override Task<UpdateProfileResult> Handle(UpdateProfileQuery request, CancellationToken cancellationToken)
        {
            var response = new UpdateProfileResult();

            try
            {
                var entity = await _context.Profiles.FirstOrDefaultAsync(x => x.Id == request.Id);

                if(entity == null)
                {
                    response.Result = false;
                    response.Message = $"Profile with id \"{request.Id}\" not found";
                }
                else
                {
                    if (!string.IsNullOrEmpty(request.Locale))
                    {
                        entity.Locale = request.Locale;
                    }

                    _context.Update(entity);
                    await _context.SaveChangesAsync();

                    response.Result = true;
                    response.Message = $"Profile updated";
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
