using FluentValidation;
using Production.Application.Dtos;
using Production.Domain.Interfaces;

namespace Production.Application.Validators
{
    public class ProductionDtoValidator : AbstractValidator<ProductionDto>
    {
        private readonly IInjectionMoldRepository _moldRepository;
        private readonly IInjectionMoldingMachineRepository _machineRepository;

        public ProductionDtoValidator(IInjectionMoldRepository moldRepository, IInjectionMoldingMachineRepository machineRepository)
        {
            _moldRepository = moldRepository;
            _machineRepository = machineRepository;

            RuleFor(e => e.Start)
                .NotNull().WithMessage("The field is required")
                .NotEmpty();

            RuleFor(e => e.End)
                .NotEmpty().WithMessage("The field is required")
                .NotNull()
                .GreaterThanOrEqualTo(v => v.Start.AddHours(1))
                .WithMessage("The End of the production must be selected after start. The minimum production time is one hour");

            RuleFor(e => e.InjectionMoldId)
                .NotEmpty().WithMessage("Select an injection mold")
                .NotNull()
                .Must(InjectionMoldIsAvailable).WithMessage("The injection mold is scheduled for another production at this time")
                .Custom((value, context) =>
                {
                    var existingMold = _moldRepository.GetById(value).Result;

                    if (existingMold == null)
                    {
                        context.AddFailure($"Mold ID: \"{value}\" doesn't exist.");
                        return;
                    }

                    if (existingMold!.MaterialId == null)
                    {
                        context.AddFailure($"Mold {existingMold.Name} has no material assigned.");
                    }
                });

            RuleFor(e => e.InjectionMoldingMachineId)
                .NotEmpty().WithMessage("Select an injection molding machine")
                .NotNull()
                .Must(InjectionMachineIsAvailable).WithMessage("The injection machine is scheduled for another production at this time")
                .Custom((value, context) =>
                {
                    var existingMachine = _machineRepository.GetById(value).Result;

                    if (existingMachine == null)
                    {
                        context.AddFailure($"Machine ID: \"{value}\" doesn't exist.");
                    }
                });
        }

        private bool InjectionMoldIsAvailable(ProductionDto productionDto, Guid moldId)
        {
            var mold = _moldRepository.GetById(moldId, true).Result;

            if (mold == null || mold.Id == default) return false;
            if (mold.Productions?.Count < 1 || mold.Productions == null) return true;

            var moldProductions = mold!.Productions!.Where(p => p.Id != productionDto.Id);

            return !IsProductionOverlapping(productionDto, moldProductions);
        }

        private bool InjectionMachineIsAvailable(ProductionDto productionDto, int machineId)
        {
            var machine = _machineRepository.GetById(machineId, true).Result;

            if (machine == null || machine.Id == default) return false;
            if (machine.Productions?.Count < 1 || machine.Productions == null) return true;

            var machineProductions = machine!.Productions!.Where(p => p.Id != productionDto.Id);

            return !IsProductionOverlapping(productionDto, machineProductions);
        }

        private bool IsProductionOverlapping(ProductionDto productionDto, IEnumerable<Domain.Entities.Production> ScheduledToolProductions)
        {
            var overlapedProduction = ScheduledToolProductions.Any(p =>
                productionDto.Start >= p.Start && productionDto.Start < p.End ||
                productionDto.End > p.Start && productionDto.End <= p.End ||
                productionDto.Start <= p.Start && productionDto.End >= p.End);

            return overlapedProduction;
        }
    }
}
