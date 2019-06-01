using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMA.App.IdentityManager.IdentityRole.Queries;

namespace UMA.App.IdentityManager.IdentityRole.Validators
{
    public class DeleteIdentityRoleQueryValidator : AbstractValidator<DeleteIdentityRoleQuery>
    {
        public DeleteIdentityRoleQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
