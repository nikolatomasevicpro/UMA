using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMA.App.Common.AutoMapper;
using UMA.App.Common.MediatR;
using UMA.Domain.Identity;

namespace UMA.App.IdentityManager.Role.Models
{
    public class RoleViewModel : BaseViewModel, IMapFrom<Domain.Identity.Role>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
