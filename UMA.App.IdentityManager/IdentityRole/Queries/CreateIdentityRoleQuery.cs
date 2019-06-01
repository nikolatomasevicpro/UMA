using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMA.App.Common.AutoMapper;
using UMA.App.IdentityManager.IdentityRole.Models;

namespace UMA.App.IdentityManager.IdentityRole.Queries
{
    public class CreateIdentityRoleQuery : IRequest<CreateIdentityRoleResult>
    {
        public Guid Identity { get; set; }
        public Guid Role { get; set; }
    }
}
