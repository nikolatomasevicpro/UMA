using MediatR;
using System;
using UMA.App.IdentityManager.Identity.Models;

namespace UMA.App.IdentityManager.Identity.Queries
{
    public class DeleteIdentityQuery : IRequest<DeleteIdentityResult>
    {
        public Guid Id { get; set; }
    }
}
