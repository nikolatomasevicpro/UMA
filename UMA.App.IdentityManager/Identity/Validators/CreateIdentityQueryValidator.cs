using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMA.App.IdentityManager.Identity.Queries;

namespace UMA.App.IdentityManager.Identity.Validators
{
    public class CreateIdentityQueryValidator : AbstractValidator<CreateIdentityQuery>
    {
        public CreateIdentityQueryValidator()
        {
            RuleFor(x => x.Login).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
