using Production.Domain.Interfaces;

namespace Production.Application.Services
{
    public interface IProductionInventoryService
    {
        Task<bool> ReserveMaterialForProduction(Guid moldId, int productionTime);
    }

    public class 
        ProductionInventoryService : IProductionInventoryService
    {
        private readonly IMaterialRepository _materialRepository;

        public ProductionInventoryService(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        public async Task<bool> ReserveMaterialForProduction(Guid moldId, int productionTime)
        {
            var material = await _materialRepository.GetByMoldId(moldId);

            if(material == null || material.InjectionMold!.Consumption < 0)
            {
                throw new NullReferenceException();
            }

            var consumption = material.InjectionMold!.Consumption;

            var usage = CalculateMaterialConsumption(productionTime, consumption);

            material.Stock.PlannedMaterialDemand += usage;

            if (material.Stock.PlannedMaterialDemand > material.Stock.MaterialInStock)
            {
                material.Stock.MaterialToOrder = material.Stock.PlannedMaterialDemand - material.Stock.MaterialInStock;
                return false;
            }

            await _materialRepository.Commit();

            return true;
        }

        private int CalculateMaterialConsumption(int productionTime, decimal consumption) => (int)Math.Ceiling(productionTime * consumption);
    }
}