using Production.Application.Dtos;

namespace Production.Application.Interfaces
{
    public interface IMaterialService
    {
        Task Create(MaterialDto materialDto);
        Task<IEnumerable<MaterialDto>> GetAll();
        Task<MaterialDto> GetById(int materialId);
        Task Remove(int materialId);
        Task Update(int materialId, MaterialDto materialDto);
    }
}