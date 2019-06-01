using System;
using System.Collections.Generic;
using UMA.App.Common.MediatR;

namespace UMA.App.IdentityManager.Authentication.Models
{
    public class BaseIdentityViewModel : BaseViewModel
    {
        public Guid Id { get; set; }
        public string Token { get; set; }
        public string Login { get; set; }
        public DateTime Expires { get; set; }
        public List<string> Roles { get; set; }
    }
}
