using Production.Application.Dtos;

namespace Production.Application.Interfaces
{
    public interface IInjectionMoldingMachineService
    {
        Task Create(InjectionMoldingMachineDto machineDto);
        Task<IEnumerable<InjectionMoldingMachineDto>> GetAll();
        Task<InjectionMoldingMachineDto> GetById(int machineId, bool withProductionInfo = false);
        Task Remove(int machineId);
        Task Update(int machineId, InjectionMoldingMachineDto machineDto);
    }
}