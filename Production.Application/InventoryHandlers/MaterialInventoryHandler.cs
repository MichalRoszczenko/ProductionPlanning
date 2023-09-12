using Production.Application.Dtos;
using Production.Application.Interfaces;
using Production.Domain.Interfaces;

namespace Production.Application.InventoryHandling
{

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

		public async Task CalculateDemands(Domain.Entities.Material material)
		{
			material.Stock.PlannedMaterialDemand = 0;
			var inStock = material.Stock.MaterialInStock;

			var productions = await _productionRepository.GetAll();
			var selectedProductions = productions.Where(s => s.InjectionMold.MaterialId == material.Id);

			foreach (var production in selectedProductions)
			{
				var usage = production.MaterialStatus.MaterialUsage;

				material.Stock.PlannedMaterialDemand += usage;

				inStock -= usage;

				if (inStock >= 0) production.MaterialStatus.MaterialIsAvailable = true;
				else production.MaterialStatus.MaterialIsAvailable = false;
			}

			material.Stock.CountMaterialToOrder();

			await _productionRepository.Commit();
		}

		public async Task RemoveMaterialFromProductions(Domain.Entities.Material material)
		{
			var productions = await _productionRepository.GetAll();
			var selectedProductions = productions.Where(s => s.InjectionMold.MaterialId == material.Id);

			foreach (var production in selectedProductions)
			{
				production.MaterialStatus.MaterialIsAvailable = false;
			}

			await _productionRepository.Commit();
		}
	}
}
