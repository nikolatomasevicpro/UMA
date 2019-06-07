using FluentValidation;
using UMA.App.IdentityManager.Profile.Queries;

namespace UMA.App.IdentityManager.Profile.Validators
{
    public class UpdateProfileQueryValidator : AbstractValidator<UpdateProfileQuery>
    {
        public UpdateProfileQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
