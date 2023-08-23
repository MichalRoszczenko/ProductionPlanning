namespace Production.Application.Productions
{
    public class ProductionDto
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int ProductionTimeInHours { get; private set; }
        public Guid InjectionMoldId { get; set; } = default!;
        public string? InjectionMoldName { get; set; }
        public int InjectionMoldingMachineId { get; set; } = default!;
        public string? InjectionMoldingMachineName { get; set; }
		public bool MaterialIsAvailable { get; set; }
		public int MaterialUsage { get; set; }
	}
}
