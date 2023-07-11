namespace Production.Domain.Interfaces
{
    public interface IProductionRepository
    {
        Task<IEnumerable<Entities.Production>> GetAll();
        Task Create(Entities.Production production);
    }
}
