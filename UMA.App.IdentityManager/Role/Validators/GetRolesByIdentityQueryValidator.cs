using FluentValidation;
using UMA.App.IdentityManager.Role.Queries;

namespace UMA.App.IdentityManager.Role.Validators
{
    public class GetRolesByIdentityQueryValidator : AbstractValidator<GetRolesByIdentityQuery>
    {
        public GetRolesByIdentityQueryValidator()
        {
            RuleFor(e => e.Id).NotEmpty();
        }
    }
}
