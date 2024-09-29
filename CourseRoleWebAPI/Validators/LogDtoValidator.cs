using CourseRoleWebAPI.Dtos;
using FluentValidation;

namespace CourseRoleWebAPI.Validators
{
    public class LogDtoValidator : AbstractValidator<LogDto>
    {
        public LogDtoValidator() {
            RuleFor(x => x.datadto)
                .NotEmpty()
                .MinimumLength(10).WithMessage("Largo minimo 10");
            RuleFor(x => x.datedto)
                .NotEmpty();
            RuleFor(x => x.userdto)
                .NotEmpty()
                .MinimumLength(5).WithMessage("Largo minimo 5")
                .MaximumLength(10).WithMessage("Largo maximo 10");
        }
    }
}
