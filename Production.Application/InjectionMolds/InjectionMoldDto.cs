namespace Production.Application.InjectionMolds
{
    public class InjectionMoldDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Producer { get; set; } = default!;
        public string Size { get; set; } = default!;
        public List<PlannedProduction>? PlannedProductions { get; set; }
    }

    public class PlannedProduction
    {
        public int ProductionId { get; set; }
        public DateTime StartProduction { get; set; }
        public DateTime EndProduction { get; set; }
    }
}
