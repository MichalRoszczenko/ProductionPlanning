using FluentValidation;

namespace Production.Application.InjectionMolds.Validators
{
    public class InjectionMoldDtoValidator : AbstractValidator<InjectionMoldDto>
    {
        public InjectionMoldDtoValidator()
        {
            RuleFor(e => e.Name)
                .NotEmpty()
                .MinimumLength(2).WithMessage("The Name should have atleast 2 characters.")
                .MaximumLength(15).WithMessage("The Name should have maximum 15 characters.");

            RuleFor(e => e.Size)
                .NotEmpty()
                .WithMessage("Please enter mold size.");

            RuleFor(e => e.Producer)
                .NotEmpty()
                .MinimumLength(2).WithMessage("The Producer should have atleast 2 characters.")
                .MaximumLength(15).WithMessage("The Producer should have maximum 15 characters.");
        }
    }
}
