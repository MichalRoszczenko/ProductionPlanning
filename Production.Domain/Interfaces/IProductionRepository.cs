namespace Production.Domain.Interfaces
{
    public interface IProductionRepository
    {
        Task<IEnumerable<Entities.Production>> GetAll();
        Task<Entities.Production> GetById(int productionId);
        Task Create(Entities.Production production);
        Task Remove(Entities.Production production);
        Task Commit();
    }
}
