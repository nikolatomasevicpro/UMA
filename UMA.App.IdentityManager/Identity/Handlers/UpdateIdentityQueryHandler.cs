using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using UMA.App.IdentityManager.Identity.Models;
using UMA.App.IdentityManager.Identity.Queries;
using UMA.Infrastructure.Crypto;
using UMA.Persistence.Identity.Context;

namespace UMA.App.IdentityManager.Identity.Handlers
{
    public class UpdateIdentityQueryHandler : IdentityManagerBaseHandler<UpdateIdentityQuery, UpdateIdentityResult>
    {
        public UpdateIdentityQueryHandler(IdentityDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async override Task<UpdateIdentityResult> Handle(UpdateIdentityQuery request, CancellationToken cancellationToken)
        {
            var response = new UpdateIdentityResult();

            try
            {
                var entity = await _context.Identities.FirstOrDefaultAsync(x => x.Id == request.Id);

                if (entity == null)
                {
                    response.Result = false;
                    response.Message = $"Identity with id \"{request.Id}\" not found";
                }
                else
                {
                    if (!string.IsNullOrEmpty(request.Login))
                    {
                        entity.Login = request.Login;
                    }

                    if(!string.IsNullOrEmpty(request.Password))
                    {
                        entity.Password = PasswordEncrypter.Hash(request.Password, entity.Salt);
                    }

                    _context.Update(entity);
                    await _context.SaveChangesAsync();

                    response.Result = true;
                    response.Message = $"Entity \"{entity.Login}\" updated";
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
