namespace Production.Domain.Interfaces
{
    public interface IProductionRepository
    {
        Task<IEnumerable<Domain.Entities.Production>> GetAll();
    }
}
