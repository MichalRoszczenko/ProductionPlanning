using Production.Application.InventoryHandling;
using Production.Domain.Entities;

namespace Production.Application.Interfaces
{
    public interface IMaterialInventoryHandler
    {
        void AddMaterialDemand(Material material, MaterialRequirements materialRequirementsInfo);
        Task CalculateDemands(Material material);
        void RemoveMaterialDemand(Material material, MaterialRequirements materialRequirementsInfo);
        Task RemoveMaterialFromProduction(Material material);
    }
}