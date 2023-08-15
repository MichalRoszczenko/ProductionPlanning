using FluentValidation;

namespace Production.Application.InjectionMolds.Validators
{
    public class InjectionMoldDtoValidator : AbstractValidator<InjectionMoldDto>
    {
        public InjectionMoldDtoValidator()
        {
            RuleFor(e => e.Name)
                .NotEmpty().WithMessage("Please enter the injection mold Name.")
                .NotNull()
                .MinimumLength(2).WithMessage("The Name should have atleast 2 characters.")
                .MaximumLength(15).WithMessage("The Name should have maximum 15 characters.");

            RuleFor(e => e.Size)
                .NotEmpty().WithMessage("Please enter mold Size.")
                .NotNull();

            RuleFor(e => e.Producer)
                .NotEmpty().WithMessage("Please enter Producer name.")
                .NotNull()
                .MinimumLength(2).WithMessage("The Producer should have atleast 2 characters.")
                .MaximumLength(15).WithMessage("The Producer should have maximum 15 characters.");

            RuleFor(e => e.Consumption)
                .PrecisionScale(4,2,true).WithMessage("The value of the 'Consumption' field cannot have more than 4 digits with a maximum accuracy of 2 digits after the decimal point. ")
                .GreaterThan(0).WithMessage("Consumption should be greater than 0");
        }
    }
}
