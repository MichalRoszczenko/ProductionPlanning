namespace Production.Application.InventoryHandling
{
    public class MaterialInformationDto
    {
        public MaterialInformationDto(int productionTime, decimal consumption)
        {
            ProductionTime = productionTime;
            Consumption = consumption;
            Usage = (int)Math.Ceiling(productionTime * consumption);
        }

        public int ProductionTime { get; }
        public decimal Consumption { get; }
        public int Usage { get; }
    }
}
