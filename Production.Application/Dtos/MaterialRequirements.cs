namespace Production.Application.Dtos
{
    public class MaterialRequirements
    {
        public int ProductionTime { get; }
        public decimal Consumption { get; }
        public int Usage { get; }

        public MaterialRequirements(int productionTime, decimal consumption)
        {
            ProductionTime = productionTime;
            Consumption = consumption;
            Usage = (int)Math.Ceiling(productionTime * consumption);
        }
    }
}
