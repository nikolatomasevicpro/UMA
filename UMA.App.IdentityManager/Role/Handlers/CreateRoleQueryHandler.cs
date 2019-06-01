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
    public class CreateRoleQueryHandler : IdentityManagerBaseHandler<CreateRoleQuery, CreateRoleResult>
    {
        public CreateRoleQueryHandler(IdentityDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async override Task<CreateRoleResult> Handle(CreateRoleQuery request, CancellationToken cancellationToken)
        {
            var response = new CreateRoleResult();

            try
            {
                var result = await _context.Roles.Where(e => e.Name == request.Name || e.Description == request.Description).FirstOrDefaultAsync();

                if (result == null)
                {
                    var operationResult = await _context.AddAsync(_mapper.Map<Domain.Identity.Role>(request));

                    if (operationResult.IsKeySet)
                    {
                        response.Id = operationResult.Entity.Id;
                        await _context.SaveChangesAsync(cancellationToken);

                        response.Result = true;
                        response.Message = $"Role \"{request.Name}\" created";
                    }
                }
                else
                {
                    response.Result = false;
                    response.Message = $"\"{request.Name}\" already exists";
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
