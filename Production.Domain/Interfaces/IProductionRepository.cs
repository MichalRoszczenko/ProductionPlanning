using Production.Domain.Entities;

namespace Production.Domain.Interfaces
{
    public interface IProductionRepository
    {
        Task<IEnumerable<Entities.Production>> GetAll();
        Task Create(Entities.Production production);
        Task Remove(Entities.Production production);
        Task Commit();
    }
}
