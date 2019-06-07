using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMA.App.IdentityManager.Profile.Models;

namespace UMA.App.IdentityManager.Profile.Queries
{
    public class UpdateProfileQuery : IRequest<UpdateProfileResult>
    {
        public Guid Id { get; set; }
        public string Locale { get; set; }
    }
}
