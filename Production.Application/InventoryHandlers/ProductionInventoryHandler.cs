using Production.Application.Dtos;
using Production.Application.Interfaces;
using Production.Application.InventoryHandling;
using Production.Domain.Interfaces;

namespace Production.Application.InventoryHandlers
{
    public class ProductionInventoryHandler : IProductionInventoryHandler
	{
		private readonly IMaterialRepository _materialRepository;
		private readonly IInjectionMoldRepository _injectionMoldRepository;
		private readonly IMaterialInventoryHandler _materialHandler;

		public ProductionInventoryHandler(IMaterialRepository materialRepository, IMaterialInventoryHandler materialHandler,
			IInjectionMoldRepository injectionMoldRepository)
		{
			_materialRepository = materialRepository;
			_injectionMoldRepository = injectionMoldRepository;
			_materialHandler = materialHandler;
		}

		public async Task<MaterialStatusDto> AddMaterialReservation(Domain.Entities.Production production)
		{
			var materialRequirements = await CreateMaterialRequirementsInfo(production);

			var material = await _materialRepository.GetByMoldId(production.InjectionMoldId);

			_materialHandler.AddMaterialDemand(material, materialRequirements);

			return new MaterialStatusDto(material, materialRequirements.Usage);
		}

		public async Task RemoveMaterialReservation(Domain.Entities.Production production)
		{
			var materialRequirements = await CreateMaterialRequirementsInfo(production);

			var material = await _materialRepository.GetByMoldId(production.InjectionMoldId);

			_materialHandler.RemoveMaterialDemand(material, materialRequirements);

			await _materialHandler.CalculateDemands(material);
		}

		private async Task<MaterialRequirements> CreateMaterialRequirementsInfo(Domain.Entities.Production production)
		{
			var injectionMold = await _injectionMoldRepository.GetById(production.InjectionMoldId);

			var consumption = injectionMold!.Consumption;

			var productionTime = production.ProductionTimeInHours;

			return new MaterialRequirements(productionTime, consumption);
		}
	}
}