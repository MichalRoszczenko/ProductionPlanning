using FluentValidation;
using Production.Application.Dtos;

namespace Production.Application.Validators
{
    public class InjectionMoldingMachineDtoValidator : AbstractValidator<InjectionMoldingMachineDto>
    {
        public InjectionMoldingMachineDtoValidator()
        {
            RuleFor(x => x.Name)
                .MinimumLength(2).WithMessage("The Name should have atleast 2 characters")
                .MaximumLength(15).WithMessage("The Name should have maximum 15 characters")
                .NotEmpty().WithMessage("Please enter machine Name")
                .NotNull();

            RuleFor(x => x.Tonnage)
                .GreaterThan(0).WithMessage("Machine tonnage should be greater than 0")
                .LessThan(4000).WithMessage("Machine tonnage should be less than 4000")
                .NotEmpty().WithMessage("Please enter machine Tonnage")
                .NotNull();

            RuleFor(x => x.Size)
                .NotEmpty().WithMessage("Please enter machine Size.")
                .NotNull()
                .MaximumLength(15).WithMessage("The Size should have maximum 15 characters");

		}
    }
}
