using FluentValidation;
using UMA.App.IdentityManager.Role.Queries;

namespace UMA.App.IdentityManager.Role.Validators
{
    public class GetRoleQueryValidator : AbstractValidator<GetRoleQuery>
    {
        public GetRoleQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().When(x => string.IsNullOrEmpty(x.Name) && string.IsNullOrEmpty(x.Description)).WithMessage(@"All the properties are empty. At least one property needs to be filled");
            RuleFor(x => x.Name).NotEmpty().When(x => !x.Id.HasValue && string.IsNullOrEmpty(x.Description)).WithMessage(@"All the properties are empty. At least one property needs to be filled");
            RuleFor(x => x.Description).NotEmpty().When(x => !x.Id.HasValue && string.IsNullOrEmpty(x.Name)).WithMessage(@"All the properties are empty. At least one property needs to be filled");
        }
    }
}
