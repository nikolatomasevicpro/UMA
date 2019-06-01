using FluentValidation;
using UMA.App.IdentityManager.Identity.Queries;

namespace UMA.App.IdentityManager.Identity.Validators
{
    public class GetAllIdentitiesQueryValidator : AbstractValidator<GetAllIdentitiesQuery>
    {
        public GetAllIdentitiesQueryValidator()
        {
        }
    }
}
