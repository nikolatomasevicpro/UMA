using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMA.App.IdentityManager.IdentityRole.Queries;

namespace UMA.App.IdentityManager.IdentityRole.Validators
{
    public class CreateIdentityRoleQueryValidator : AbstractValidator<CreateIdentityRoleQuery>
    {
        public CreateIdentityRoleQueryValidator()
        {
            RuleFor(x => x.Identity).NotEmpty();
            RuleFor(x => x.Role).NotEmpty();
        }
    }
}
