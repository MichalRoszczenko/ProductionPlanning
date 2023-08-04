namespace Production.Domain.Entities
{
    public class MaterialStock
    {
        public int MaterialInStock { get; set; } = 0;
        public int MaterialScheduledInStock { get; set; } = 0;
        public int MaterialOnProduction { get; set; } = 0;
        public int MaterialLeft { get; private set; }

        public int CountMaterial() => MaterialInStock - MaterialScheduledInStock - MaterialOnProduction;
    }
}
