using Production.Application.Dtos;

namespace Production.Application.Interfaces
{
    public interface IProductionInventoryHandler
    {
        Task<MaterialStatusDto> AddMaterialReservation(Domain.Entities.Production production);
        Task RemoveMaterialReservation(Domain.Entities.Production production);
    }
}