using FluentValidation;

namespace Production.Application.Material.Validetors
{
    public class MaterialValidator : AbstractValidator<MaterialDto>
    {
        public MaterialValidator()
        {
            RuleFor(e => e.Name)
                .NotEmpty().WithMessage("Please enter material Name")
                .NotNull()
                .MinimumLength(2).WithMessage("The Name should have atleast 2 characters.")
                .MaximumLength(15).WithMessage("The Name should have maximum 15 characters.");

            RuleFor(e => e.Type)
                .NotEmpty().WithMessage("Please enter material Type")
                .NotNull()
                .MinimumLength(2).WithMessage("The Type should have atleast 2 characters.")
                .MaximumLength(15).WithMessage("The Type should have maximum 15 characters.");

            RuleFor(e => e.Description)
                .NotEmpty().WithMessage("Please enter material Description")
                .NotNull()
                .MaximumLength(32).WithMessage("The maximum number of characters for the description is 32.");

            RuleFor(e => e.MaterialInStock)
                .NotEmpty().WithMessage("Please enter actual amount of material in the stack")
                .NotNull().WithMessage("Enter amount of material in stock");
        }
    }
}
