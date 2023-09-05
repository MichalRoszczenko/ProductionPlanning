namespace Production.Application.Dtos
{
    public class InjectionMoldDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Producer { get; set; } = default!;
        public string Size { get; set; } = default!;
        public decimal Consumption { get; set; } = default!;
        public List<PlannedProductionDto>? PlannedProductions { get; set; }
        public int? MaterialId { get; set; }
    }
}
