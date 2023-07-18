namespace Production.Application.Productions
{
    public class ProductionDtoOutput
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int ProductionTimeInHours { get; set; }
        public string InjectionMoldName { get; set; } = default!;
        public string InjectionMoldingMachineName { get; set; } = default!;
    }
}
