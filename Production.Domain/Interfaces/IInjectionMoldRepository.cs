using Production.Domain.Entities;

namespace Production.Domain.Interfaces
{
    public interface IInjectionMoldRepository
    {
        Task<InjectionMold?> GetById(Guid moldId, bool withProductionInfo = false);
        Task<IEnumerable<InjectionMold>?> GetAll();
        Task Create(InjectionMold injectionMold);
        Task Remove(Guid moldId);
        Task Commit();
    }
}
