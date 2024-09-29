using CourseRoleWebAPI.Dtos;
using FluentValidation;

namespace CourseRoleWebAPI.Validators
{
    public class CourseDtoValidator : AbstractValidator<CourseDto>
    {
        public CourseDtoValidator() {
            RuleFor(x => x.namedto)
                .NotEmpty()
                .MinimumLength(6).WithMessage("Largo minimo 6")
                .MaximumLength(50).WithMessage("Largo maximo 50");
            RuleFor(x => x.descriptiondto)
                .NotEmpty()
                .MinimumLength(5).WithMessage("Largo minimo 5")
                .MaximumLength(100).WithMessage("Largo maximo 100");
        }
    }
}
