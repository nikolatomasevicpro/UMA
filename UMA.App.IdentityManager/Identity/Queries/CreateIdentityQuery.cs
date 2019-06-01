using AutoMapper;
using MediatR;
using UMA.App.Common.AutoMapper;
using UMA.App.IdentityManager.Identity.Models;
using UMA.Domain.Identity;

namespace UMA.App.IdentityManager.Identity.Queries
{
    public class CreateIdentityQuery : IRequest<CreateIdentityResult>, IHaveCustomMapping
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public void CreateMappings(AutoMapper.Profile configuration)
        {
            configuration.CreateMap<CreateIdentityQuery, Domain.Identity.Identity>();
        }
    }
}
