namespace ProductionPlanning.Entities
{
    public class Production
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int ProductionTimeInHours { get; set; }
        public InjectionMold InjectionMold { get; set; }
        public int InjectionMoldId { get; set; }        
        public InjectionMoldingMachine InjectionMoldingMachine { get; set; }
        public int InjectionMoldingMachineId { get; set; }

    }
}
