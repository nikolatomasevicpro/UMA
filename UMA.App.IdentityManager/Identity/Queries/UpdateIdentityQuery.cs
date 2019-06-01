using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMA.App.IdentityManager.Identity.Models;

namespace UMA.App.IdentityManager.Identity.Queries
{
    public class UpdateIdentityQuery : IRequest<UpdateIdentityResult>
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
