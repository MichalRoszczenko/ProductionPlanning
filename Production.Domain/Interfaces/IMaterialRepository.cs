using Production.Domain.Entities;

namespace Production.Domain.Interfaces
{
    public interface IMaterialRepository
    {
        Task<IEnumerable<Material>> GetAll();
        Task<Material> GetById(int materialId);
        Task Create(Material material);
    }
}
