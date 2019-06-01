using FluentValidation;
using UMA.App.IdentityManager.Authentication.Queries;

namespace UMA.App.IdentityManager.Authentication.Validators
{
    public class RegisterUserQueryValidator : AbstractValidator<RegisterUserQuery>
    {
        public RegisterUserQueryValidator()
        {
            RuleFor(x => x.Login).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}