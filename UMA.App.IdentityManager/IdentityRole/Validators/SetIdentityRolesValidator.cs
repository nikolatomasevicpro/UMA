using FluentValidation;
using UMA.App.IdentityManager.IdentityRole.Queries;

namespace UMA.App.IdentityManager.IdentityRole.Validators
{
    public class SetIdentityRolesValidator : AbstractValidator<SetIdentityRolesQuery>
    {
        public SetIdentityRolesValidator()
        {
            RuleFor(e => e.Identity).NotEmpty();
            RuleFor(e => e.Roles).NotEmpty();
        }
    }
}
