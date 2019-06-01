using System.Collections.Generic;
using UMA.App.Common.MediatR;

namespace UMA.App.IdentityManager.Identity.Models
{
    public class IdentitiesViewModel : BaseViewModel
    {
        public List<IdentityViewModel> Identities { get; set; }
    }
}
