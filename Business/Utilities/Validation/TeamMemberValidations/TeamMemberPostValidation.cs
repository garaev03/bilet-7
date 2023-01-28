using FluentValidation;
using Studio.Entities.DTOs.TeamMemberDtos;

namespace Studio.Business.Utilities.Validation.TeamMemberValidations
{
    public class TeamMemberPostValidation:AbstractValidator<TeamMemberPostDto>
    {
        public TeamMemberPostValidation()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MinimumLength(2);
            RuleFor(x => x.Position).NotEmpty().NotNull().MinimumLength(2);
            RuleFor(x => x.TwitterLink).NotEmpty().NotNull().MinimumLength(2);
            RuleFor(x => x.FacebookLink).NotEmpty().NotNull().MinimumLength(2);
            RuleFor(x => x.LinkedinLink).NotEmpty().NotNull().MinimumLength(2);
        }
    }
}
