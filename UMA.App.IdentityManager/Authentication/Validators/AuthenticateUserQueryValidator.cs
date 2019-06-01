using FluentValidation;
using UMA.App.IdentityManager.Authentication.Queries;

namespace UMA.App.IdentityManager.Authentication.Validators
{
    public class AuthenticateUserQueryValidator : AbstractValidator<AuthenticateUserQuery>
    {
        public AuthenticateUserQueryValidator()
        {
            RuleFor(x => x.Login).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
