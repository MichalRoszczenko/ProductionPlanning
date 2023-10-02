using Production.Application.Dtos;
using Production.Application.Interfaces;
using Production.Domain.Entities;
using Production.Domain.Interfaces;

namespace Production.Application.InventoryHandling
{

    internal sealed class MaterialInventoryHandler : IMaterialInventoryHandler
	{
		private readonly IProductionRepository _productionRepository;

		public MaterialInventoryHandler(IProductionRepository productionRepository)
		{
			_productionRepository = productionRepository;
		}

		public void AddMaterialDemand(Material material, MaterialRequirements materialRequirementsInfo)
		{
			material.Stock.PlannedMaterialDemand += materialRequirementsInfo.Usage;

			material.Stock.CountMaterialToOrder();
		}

		public void RemoveMaterialDemand(Material material, MaterialRequirements materialRequirementsInfo)
		{
			material.Stock.PlannedMaterialDemand -= materialRequirementsInfo.Usage;

			material.Stock.CountMaterialToOrder();
		}

		public async Task CalculateDemands(Material material)
		{
			await RecalculateProductionMaterial(material);

			material.Stock.CountMaterialToOrder();

			await _productionRepository.Commit();
		}

		private async Task RecalculateProductionMaterial(Material material)
		{
			material.Stock.PlannedMaterialDemand = 0;
			var inStock = material.Stock.MaterialInStock;

			var productions = await _productionRepository.GetAll();
			var selectedProductions = productions.Where(s => s.InjectionMold.MaterialId == material.Id);

			foreach (var production in selectedProductions)
			{
				var usage = (int)Math.Ceiling(production.ProductionTimeInHours * production.InjectionMold.Consumption);

				material.Stock.PlannedMaterialDemand += usage;

				inStock -= usage;

				production.MaterialStatus.MaterialUsage = usage;
				if (inStock >= 0) production.MaterialStatus.MaterialIsAvailable = true;
				else production.MaterialStatus.MaterialIsAvailable = false;
			}
		}

		public async Task RemoveMaterialFromProductions(Material material)
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
