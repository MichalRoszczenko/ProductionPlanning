namespace Production.Application.Material
{
    public class MaterialDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Type { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Cost { get; set; }

        public int MaterialInStock { get; set; } = 0;
        public int PlannedMaterialDemand { get; set; } = 0;
        public int MaterialToOrder { get; set; } = 0;
        public int MaterialOnProduction { get; set; } = 0;
    }
}
