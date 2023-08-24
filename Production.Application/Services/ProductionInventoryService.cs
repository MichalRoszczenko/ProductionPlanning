using Production.Application.InventoryHandling;
using Production.Domain.Interfaces;

namespace Production.Application.Services
{
    public interface IProductionInventoryService
    {
        Task<MaterialStatusDto> AddMaterialReservation(Domain.Entities.Production production);
        Task RemoveMaterialReservation(Domain.Entities.Production production);
        Task<MaterialStatusDto> CheckMaterialReservation(Domain.Entities.Production production);
    }

    public class ProductionInventoryService : IProductionInventoryService
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IInjectionMoldRepository _injectionMoldRepository;
        private readonly IMaterialInventoryHandler _materialHandler;

        public ProductionInventoryService(IMaterialRepository materialRepository, IMaterialInventoryHandler materialHandler,
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

            _materialHandler.RemoveMaterialDemand(material,materialRequirements);

            await _materialHandler.CalculateDemands(material);
        }

        public async Task<MaterialStatusDto> CheckMaterialReservation(Domain.Entities.Production production)
        {
            var materialRequirements = await CreateMaterialRequirementsInfo(production);

            var material = await _materialRepository.GetByMoldId(production.InjectionMoldId);

            _materialHandler.CheckMaterialDemand(material);

            return new MaterialStatusDto(material, materialRequirements.Usage);
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