namespace Production.Application.Production
{
    public class ProductionDto
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int ProductionTimeInHours { get; set; }
        public string InjectionMoldName { get; set; } = default!;
        public int InjectionMoldingMachineName { get; set; }
    }
}
