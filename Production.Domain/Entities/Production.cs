namespace Production.Domain.Entities
{
    public class Production
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int ProductionTimeInHours { get; set; }
        public InjectionMold InjectionMold { get; set; } = default!;
        public Guid InjectionMoldId { get; set; }
        public InjectionMoldingMachine InjectionMoldingMachine { get; set; } = default!;
        public int InjectionMoldingMachineId { get; set; }

        public void ProductionTimeCalculation() => ProductionTimeInHours = (End - Start).Hours;
    }
}
