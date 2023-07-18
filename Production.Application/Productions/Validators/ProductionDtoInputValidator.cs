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
                .NotEmpty()
                .LessThan(s => s.End)
                .WithMessage("Start of production cannot take place after end of production.");

            RuleFor(e => e.End)
                .NotEmpty()
                .NotNull()
                .GreaterThan(s => s.Start)
                .WithMessage("End of production cannot take place before start of production.");

            RuleFor(e => e.InjectionMoldId)
                .NotEmpty()
                .NotNull()
                .Custom((value, context) =>
                {
                    var existingMachine = moldRepository.GetById(value).Result;

                    if (existingMachine == null)
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
