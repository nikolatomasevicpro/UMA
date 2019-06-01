using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMA.App.IdentityManager.Role.Queries;

namespace UMA.App.IdentityManager.Role.Validators
{
    public class UpdateRoleQueryValidator : AbstractValidator<UpdateRoleQuery>
    {
        public UpdateRoleQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
