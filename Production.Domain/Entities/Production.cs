namespace Production.Domain.Entities
{
    public class Production
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int ProductionTimeInHours { get; private set; }
        public InjectionMold InjectionMold { get; set; } = default!;
        public Guid InjectionMoldId { get; set; }
        public InjectionMoldingMachine InjectionMoldingMachine { get; set; } = default!;
        public int InjectionMoldingMachineId { get; set; }

        public void ProductionTimeCalculation()
        {
            if(Start > End )
            {
                throw new ArgumentException("End of production cannot take place before start of production.");
            }
            ProductionTimeInHours = (int)Math.Ceiling((End - Start).TotalMinutes / 60);
        }
    }
}
