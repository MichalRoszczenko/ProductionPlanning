using Production.Domain.Entities;

namespace Production.Domain.Interfaces
{
    public interface IInjectionMoldingMachineRepository
    {
        Task<InjectionMoldingMachine?> GetById(int machineId);
    }
}
