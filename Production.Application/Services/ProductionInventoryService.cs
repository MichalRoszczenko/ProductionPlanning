using Production.Application.InventoryHandling;
using Production.Domain.Interfaces;

namespace Production.Application.Services
{
    public interface IProductionInventoryService
    {
        Task<bool> IsMaterialInStock(Domain.Entities.Production production);
    }

    public class ProductionInventoryService : IProductionInventoryService
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IMaterialInventoryHandler _inventoryHandler;

        public ProductionInventoryService(IMaterialRepository materialRepository, IMaterialInventoryHandler inventoryHandler)
        {
            _materialRepository = materialRepository;
            _inventoryHandler = inventoryHandler;
        }

        public async Task<bool> IsMaterialInStock(Domain.Entities.Production production)
        {
            var material = await _materialRepository.GetByMoldId(production.InjectionMoldId);

            var materialInfo = _inventoryHandler.GetMaterialInformation(production.ProductionTimeInHours, material);

            _inventoryHandler.UpdateMaterialInformation(material, materialInfo);

            var isAvalaiable = IsAvalaible(material);

            await _materialRepository.Commit();

            return isAvalaiable;
        }

        private bool IsAvalaible(Domain.Entities.Material material)
        {
            if (material.Stock.PlannedMaterialDemand > material.Stock.MaterialInStock)
            {
                return false;
            }
            else return true;
        }
    }
}