namespace Production.Application.InventoryHandling
{
    public class MaterialRequirements
    {
        public int ProductionTime { get; }
        public decimal Consumption { get; }
        public int Usage { get; }
        public MaterialDirection MaterialDirection { get; set; }

		public MaterialRequirements(int productionTime, decimal consumption, MaterialDirection materialDirection)
		{
			ProductionTime = productionTime;
			Consumption = consumption;
			MaterialDirection = materialDirection;
			Usage = (int)Math.Ceiling(productionTime * consumption);
		}		
	}

    public enum MaterialDirection
    {
        Add,
        Remove,
        Update
    }
}
