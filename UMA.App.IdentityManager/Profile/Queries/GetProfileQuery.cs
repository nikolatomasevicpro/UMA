using MediatR;
using System;
using UMA.App.IdentityManager.Profile.Models;

namespace UMA.App.IdentityManager.Profile.Queries
{
    public class GetProfileQuery : IRequest<ProfileViewModel>
    {
        public Guid? Id { get; set; }
        public Guid? IdentityId { get; set; }
    }
}
