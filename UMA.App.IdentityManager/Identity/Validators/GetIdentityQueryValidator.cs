using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMA.App.IdentityManager.Identity.Queries;

namespace UMA.App.IdentityManager.Identity.Validators
{
    public class GetIdentityQueryValidator : AbstractValidator<GetIdentityQuery>
    {
        public GetIdentityQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().When(x => string.IsNullOrEmpty(x.Login)).WithMessage(@"All the properties are empty. At least one property needs to be filled");
            RuleFor(x => x.Login).NotEmpty().When(x => !x.Id.HasValue).WithMessage(@"All the properties are empty. At least one property needs to be filled");
        }
    }
}
