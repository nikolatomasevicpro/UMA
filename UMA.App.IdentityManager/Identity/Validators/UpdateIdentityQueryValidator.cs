using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMA.App.IdentityManager.Identity.Queries;

namespace UMA.App.IdentityManager.Identity.Validators
{
    public class UpdateIdentityQueryValidator : AbstractValidator<UpdateIdentityQuery>
    {
        public UpdateIdentityQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
