using MediatR;
using System;
using UMA.App.IdentityManager.Identity.Models;

namespace UMA.App.IdentityManager.Identity.Queries
{
    public class GetIdentityQuery : IRequest<IdentityViewModel>
    {
        public Guid? Id { get; set; }
        public string Login { get; set; }
    }
}
