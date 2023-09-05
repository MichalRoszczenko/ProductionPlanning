namespace Production.Application.Dtos
{
    public class MaterialStatusDto
    {
        public bool MaterialIsAvailable { get; private set; }

        public int MaterialUsage { get; private set; }

        public MaterialStatusDto(Domain.Entities.Material material, int usage)
        {
            MaterialIsAvailable = material.Stock.PlannedMaterialDemand <= material.Stock.MaterialInStock;
            MaterialUsage = usage;
        }
    }
}
