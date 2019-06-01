using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UMA.App.IdentityManager.Identity.Models;
using UMA.App.IdentityManager.Identity.Queries;
using UMA.Infrastructure.Crypto;
using UMA.Persistence.Identity.Context;

namespace UMA.App.IdentityManager.Identity.Handlers
{
    public class CreateIdentityQueryHandler : IdentityManagerBaseHandler<CreateIdentityQuery, CreateIdentityResult>
    {
        public CreateIdentityQueryHandler(IdentityDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async override Task<CreateIdentityResult> Handle(CreateIdentityQuery request, CancellationToken cancellationToken)
        {
            var response = new CreateIdentityResult();

            try
            {
                var result = await _context.Identities.Where(e => e.Login == request.Login).FirstOrDefaultAsync();

                if(result == null)
                {
                    var hashResult = PasswordEncrypter.Hash(request.Password);
                    var operationResult = await _context.AddAsync(new Domain.Identity.Identity
                    {
                        Login = request.Login,
                        Password = hashResult.Hash,
                        Salt = hashResult.Salt
                    });

                    if(operationResult.IsKeySet)
                    {
                        operationResult.Entity.Profile = new Domain.Identity.Profile();
                        response.Id = operationResult.Entity.Id;
                        await _context.SaveChangesAsync(cancellationToken);

                        response.Result = true;
                        response.Message = $"Identity for \"{request.Login}\" created";
                    }
                }
                else
                {
                    response.Result = false;
                    response.Message = $"\"{request.Login}\" already exists";
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
