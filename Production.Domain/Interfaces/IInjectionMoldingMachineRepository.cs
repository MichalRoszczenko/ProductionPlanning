using Production.Domain.Entities;

namespace Production.Domain.Interfaces
{
    public interface IInjectionMoldingMachineRepository
    {
        Task<InjectionMoldingMachine?> GetById(int machineId);
        Task<IEnumerable<InjectionMoldingMachine>> GetAll();
        Task Create(InjectionMoldingMachine injectionMachine);
        Task Remove(int machineId);
        Task Commit();
    }
}
