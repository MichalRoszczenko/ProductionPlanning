using Production.Application.Dtos;

namespace Production.Application.Interfaces
{
    public interface IInjectionMoldService
    {
        Task Create(InjectionMoldDto moldDto);
        Task<IEnumerable<InjectionMoldDto>> GetAll();
        Task<InjectionMoldDto> GetById(Guid moldId, bool withProductionInfo = false);
        Task Remove(Guid moldId);
        Task Update(Guid moldId, InjectionMoldDto moldDto);
    }
}