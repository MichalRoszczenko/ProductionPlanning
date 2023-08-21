namespace Production.Application.InventoryHandling
{
    public interface IMaterialInventoryHandler
    {
        void UpdateMaterialStock(Domain.Entities.Material material, MaterialRequirements materialRequirements);
    }

    public class MaterialInventoryHandler : IMaterialInventoryHandler
    {
        public void UpdateMaterialStock(Domain.Entities.Material material, MaterialRequirements materialRequirements)
        {
            if (materialRequirements.MaterialDirection == MaterialDirection.Add)
            {
                AddMaterialDemand(material, materialRequirements);
            }
            else if (materialRequirements.MaterialDirection == MaterialDirection.Remove)
            {
                RemoveMaterialDemand(material, materialRequirements);
            }
            else if (materialRequirements.MaterialDirection == MaterialDirection.Update)
            {
                CheckMaterialDemand(material);
			}
            else throw new ArgumentException("Material Direction mismatched");
		}

		private void AddMaterialDemand(Domain.Entities.Material material, MaterialRequirements materialRequirementsInfo)
        {
            material.Stock.PlannedMaterialDemand += materialRequirementsInfo.Usage;

            material.Stock.CountMaterialToOrder();
        }

        private void RemoveMaterialDemand(Domain.Entities.Material material, MaterialRequirements materialRequirementsInfo)
        {
            material.Stock.PlannedMaterialDemand -= materialRequirementsInfo.Usage;

            material.Stock.CountMaterialToOrder();
        }

		private void CheckMaterialDemand(Domain.Entities.Material material)
		{
			material.Stock.CountMaterialToOrder();
		}
	}
}
