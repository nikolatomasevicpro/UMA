using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMA.App.Common.MediatR;

namespace UMA.App.IdentityManager.IdentityRole.Models
{
    public class CreateIdentityRoleResult : BaseViewModel
    {
        public Guid? Id { get; set; }
    }
}
