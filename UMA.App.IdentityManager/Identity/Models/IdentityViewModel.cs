using System;
using UMA.App.Common.AutoMapper;
using UMA.App.Common.MediatR;

namespace UMA.App.IdentityManager.Identity.Models
{
    public class IdentityViewModel : BaseViewModel, IMapFrom<Domain.Identity.Identity>
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
