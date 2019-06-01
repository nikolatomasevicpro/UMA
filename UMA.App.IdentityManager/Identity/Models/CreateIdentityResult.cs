using System;
using UMA.App.Common.MediatR;

namespace UMA.App.IdentityManager.Identity.Models
{
    public class CreateIdentityResult : BaseViewModel
    {
        public Guid? Id { get; set; }
    }
}
