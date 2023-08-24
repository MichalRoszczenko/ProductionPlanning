using Production.Domain.Interfaces;

namespace Production.Application.InventoryHandling
{
	public interface IMaterialInventoryHandler
	{
		void AddMaterialDemand(Domain.Entities.Material material, MaterialRequirements materialRequirementsInfo);
		void CheckMaterialDemand(Domain.Entities.Material material);
		void RemoveMaterialDemand(Domain.Entities.Material material, MaterialRequirements materialRequirementsInfo);
        Task CalculateDemands(Domain.Entities.Material material);
    }

	public class MaterialInventoryHandler : IMaterialInventoryHandler
    {
        private readonly IProductionRepository _productionRepository;

        public MaterialInventoryHandler(IProductionRepository productionRepository)
        {
			_productionRepository = productionRepository;
        }
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

		public async Task CalculateDemands(Domain.Entities.Material material)
		{
            var startDemand = material.Stock.PlannedMaterialDemand;
            var inStock = material.Stock.MaterialInStock;
            material.Stock.PlannedMaterialDemand = 0;

            var productions = await _productionRepository.GetAll();
            var selectedProductions = productions.Where(s=>s.InjectionMold.MaterialId == material.Id);

            foreach (var production in selectedProductions)
            {
                var usage = production.MaterialStatus.MaterialUsage;

                material.Stock.PlannedMaterialDemand += usage;

                inStock -= usage;

                if (inStock> 0) production.MaterialStatus.MaterialIsAvailable = true;
                else production.MaterialStatus.MaterialIsAvailable = false;
            }
            
            await _productionRepository.Commit();
        }
	}
}
