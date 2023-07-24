using FluentValidation;

namespace Production.Application.InjectionMoldMachines.Validators
{
    public class InjectionMoldingMachineDtoValidator : AbstractValidator<InjectionMoldingMachineDto>
    {
        public InjectionMoldingMachineDtoValidator()
        {
            RuleFor(x => x.Id)
                .Empty();

            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2).WithMessage("The Name should have atleast 2 characters.")
                .MaximumLength(15).WithMessage("The Name should have maximum 15 characters.");

            RuleFor(x => x.Tonnage)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0).WithMessage("Machine tonnage should be greater than 0")
                .LessThan(4000).WithMessage("Machine tonnage should be less than 4000");
        }
    }
}
