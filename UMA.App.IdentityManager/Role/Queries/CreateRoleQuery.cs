using MediatR;
using UMA.App.Common.AutoMapper;
using UMA.App.IdentityManager.Role.Models;

namespace UMA.App.IdentityManager.Role.Queries
{
    public class CreateRoleQuery : IRequest<CreateRoleResult>, IHaveCustomMapping
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public void CreateMappings(AutoMapper.Profile configuration)
        {
            configuration.CreateMap<CreateRoleQuery, Domain.Identity.Role>();
        }
    }
}
