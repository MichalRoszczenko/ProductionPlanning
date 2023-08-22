namespace Production.Application.InventoryHandling
{
	public interface IMaterialInventoryHandler
	{
		void AddMaterialDemand(Domain.Entities.Material material, MaterialRequirements materialRequirementsInfo);
		void CheckMaterialDemand(Domain.Entities.Material material);
		void RemoveMaterialDemand(Domain.Entities.Material material, MaterialRequirements materialRequirementsInfo);
	}

	public class MaterialInventoryHandler : IMaterialInventoryHandler
    {
		public void AddMaterialDemand(Domain.Entities.Material material, MaterialRequirements materialRequirementsInfo)
        {
            material.Stock.PlannedMaterialDemand += materialRequirementsInfo.Usage;

            material.Stock.CountMaterialToOrder();
        }

		public void RemoveMaterialDemand(Domain.Entities.Material material, MaterialRequirements materialRequirementsInfo)
        {
            material.Stock.PlannedMaterialDemand -= materialRequirementsInfo.Usage;

            material.Stock.CountMaterialToOrder();
        }

		public void CheckMaterialDemand(Domain.Entities.Material material)
		{
			material.Stock.CountMaterialToOrder();
		}
	}
}
