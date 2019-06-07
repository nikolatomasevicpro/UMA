using FluentValidation;
using UMA.App.IdentityManager.Profile.Queries;

namespace UMA.App.IdentityManager.Profile.Validators
{
    public class GetProfileQueryValidator : AbstractValidator<GetProfileQuery>
    {
        public GetProfileQueryValidator()
        {
            RuleFor(x => x).Must(x => x.Id.HasValue || x.IdentityId.HasValue).WithMessage(@"At least one property must be filled");
        }
    }
}
