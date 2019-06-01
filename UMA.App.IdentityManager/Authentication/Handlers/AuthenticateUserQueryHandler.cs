using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using UMA.App.IdentityManager.Authentication.Models;
using UMA.App.IdentityManager.Authentication.Queries;
using UMA.Infrastructure.Crypto;
using UMA.Persistence.Identity.Context;

namespace UMA.App.IdentityManager.Authentication.Handlers
{
    public class AuthenticateUserQueryHandler : IdentityManagerBaseHandler<AuthenticateUserQuery, AuthenticateUserResult>
    {
        public AuthenticateUserQueryHandler(IdentityDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async override Task<AuthenticateUserResult> Handle(AuthenticateUserQuery request, CancellationToken cancellationToken)
        {
            var response = new AuthenticateUserResult();

            try
            {
                var identity = await _context.Identities.Include(x => x.IdentityRoles).ThenInclude(x => x.Role).FirstOrDefaultAsync(x => x.Login == request.Login && x.Password == PasswordEncrypter.Hash(request.Password, x.Salt, 256, 10000));

                if (identity != null && response.FillToken(identity))
                {
                    response.Result = true;
                    response.Message = "Found a match for the login/password pair.";
                }
                else
                {
                    response.Result = false;
                    response.Message = "No matching identities found with the given login/password pair";
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
