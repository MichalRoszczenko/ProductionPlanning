using FluentValidation;
using Production.Domain.Interfaces;

namespace Production.Application.Productions.Validators
{
    public class ProductionDtoValidator : AbstractValidator<ProductionDto>
    {
        private readonly IInjectionMoldRepository _moldRepository;

        public ProductionDtoValidator(IInjectionMoldRepository moldRepository, IInjectionMoldingMachineRepository machineRepository)
        {
            _moldRepository = moldRepository;

            RuleFor(e => e.Start)
                .NotNull()
                .NotEmpty();

            RuleFor(e => e.End)
                .NotEmpty()
                .NotNull()
                .GreaterThan(v => v.Start.AddHours(1))
                .WithMessage("The End of the production must be selected after start. The minimum production time is one hour");

            RuleFor(e => e.InjectionMoldId)
                .NotEmpty()
                .NotNull()
                .Must(InjectionMoldIsAvailable).WithMessage("The injection mold is scheduled for another production at this time")
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

        private bool InjectionMoldIsAvailable(ProductionDto productionDto, Guid moldId)
        {
            var mold = _moldRepository.GetById(moldId, true).Result;

            var moldProductions = mold!.Productions!.Where(p => p.Id != productionDto.Id);

            var overlapedProduction =  moldProductions.Any(p =>
                (productionDto.Start >= p.Start && productionDto.Start <= p.End) ||
                (productionDto.End >= p.Start && productionDto.End <= p.End) ||
                (productionDto.Start <= p.Start && productionDto.End >= p.End));

            return !overlapedProduction;
        }
    }
}
