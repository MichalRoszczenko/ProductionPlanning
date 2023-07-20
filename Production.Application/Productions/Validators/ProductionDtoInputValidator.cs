using FluentValidation;
using Production.Domain.Interfaces;

namespace Production.Application.Productions.Validators
{
    public class ProductionDtoInputValidator : AbstractValidator<ProductionDtoInput>
    {
        public ProductionDtoInputValidator(IInjectionMoldRepository moldRepository, IInjectionMoldingMachineRepository machineRepository)
        {
            RuleFor(e => e.Start)
                .NotNull()
                .NotEmpty();

            RuleFor(e => e.End)
                .NotEmpty()
                .NotNull()
                .GreaterThan(v => v.Start.AddHours(1))
                .WithMessage("The End of the production must be selected after start and last for at least an hour");

            RuleFor(e => e.InjectionMoldId)
                .NotEmpty()
                .NotNull()
                .Custom((value, context) =>
                {
                    var existingMold = moldRepository.GetById(value).Result;

                    if (existingMold == null)
                    {
                        context.AddFailure($"Mould ID: \"{value}\" doesn't exist.");
                    }
                });

            RuleFor(e => e.InjectionMoldingMachineId)
                .NotEmpty()
                .NotNull()
                .Custom((value, context) =>
                {
                    var existingMachine = machineRepository.GetById(value).Result;

                    if (existingMachine == null)
                    {
                        context.AddFailure($"Machine ID: \"{value}\" doesn't exist.");
                    }
                });
        }
    }
}
