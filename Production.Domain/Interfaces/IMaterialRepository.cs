using Production.Domain.Entities;

namespace Production.Domain.Interfaces
{
    public interface IMaterialRepository
    {
        Task<IEnumerable<Material>> GetAll();
        Task<Material> GetById(int materialId);
        Task<Material> GetByMoldId(Guid moldId);
        Task Create(Material material);
        Task Remove(Material material);
        Task Commit();
    }
}
