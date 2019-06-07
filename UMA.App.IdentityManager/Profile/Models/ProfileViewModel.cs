using System;
using UMA.App.Common.AutoMapper;
using UMA.App.Common.MediatR;

namespace UMA.App.IdentityManager.Profile.Models
{
    public class ProfileViewModel : BaseViewModel, IMapFrom<Domain.Identity.Profile>
    {
        public Guid Id { get; set; }
        public string Locale { get; set; }
    }
}
