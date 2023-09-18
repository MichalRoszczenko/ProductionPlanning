using FluentValidation;
using Production.Application.Dtos;

namespace Production.Application.Validators
{
    public class MaterialDtoValidator : AbstractValidator<MaterialDto>
    {
        public MaterialDtoValidator()
        {
            RuleFor(e => e.Name)
                .NotEmpty().WithMessage("Please enter the material Name")
                .NotNull()
                .MinimumLength(2).WithMessage("The Name should have atleast 2 characters.")
                .MaximumLength(15).WithMessage("The Name should have maximum 15 characters.");

            RuleFor(e => e.Type)
                .NotEmpty().WithMessage("Please enter the material Type")
                .NotNull()
                .MinimumLength(2).WithMessage("The Type should have atleast 2 characters.")
                .MaximumLength(15).WithMessage("The Type should have maximum 15 characters.");

            RuleFor(e => e.Description)
                .NotEmpty().WithMessage("Please enter the material Description")
                .NotNull()
                .MaximumLength(32).WithMessage("The maximum number of characters for the description is 32.");

            RuleFor(e => e.Cost)
				.NotEmpty().WithMessage("Please enter the material Cost.")
				.NotNull()
                .PrecisionScale(5, 2, true)
                .WithMessage("The value of the Cost field cannot have more than 5 digits with a maximum accuracy of 2 digits after the decimal point.")
                .GreaterThanOrEqualTo(0).WithMessage("Cost should be greater or equal 0");

			RuleFor(e => e.MaterialInStock)
                .NotNull().WithMessage("Enter amount of the material in stock")
                .GreaterThanOrEqualTo(0).WithMessage("Material cannot be less than 0");
        }
    }
}
