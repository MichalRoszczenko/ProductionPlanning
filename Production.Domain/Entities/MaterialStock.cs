namespace Production.Domain.Entities
{
    public class MaterialStock
    {
        public int MaterialInStock { get; set; } = 0;
        public int PlannedMaterialDemand { get; set; } = 0;
        public int MaterialToOrder { get; set; } = 0; 
        public int MaterialOnProduction { get; set; } = 0;
    }
}
