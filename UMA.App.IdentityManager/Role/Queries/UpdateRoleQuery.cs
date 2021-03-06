﻿using MediatR;
using System;
using UMA.App.IdentityManager.Role.Models;

namespace UMA.App.IdentityManager.Role.Queries
{
    public class UpdateRoleQuery : IRequest<UpdateRoleResult>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
