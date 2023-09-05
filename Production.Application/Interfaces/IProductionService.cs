using Production.Application.Dtos;

namespace Production.Application.Interfaces
{
    public interface IProductionService
    {
        Task Create(ProductionDto productionDto);
        Task<IEnumerable<ProductionDto>> GetAll();
        Task<ProductionDto> GetById(int id);
        Task Remove(int productionId);
        Task Update(int productionId, ProductionDto productionDto);
    }
}