using MediatR;
using System;
using UMA.App.IdentityManager.Role.Models;

namespace UMA.App.IdentityManager.Role.Queries
{
    public class GetRolesByIdentityQuery : IRequest<RolesViewModel>
    {
        public Guid Id { get; set; }
    }
}
