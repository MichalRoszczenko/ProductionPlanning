using Production.Domain.Entities;

namespace Production.Domain.Interfaces
{
    public interface IInjectionMoldRepository
    {
        Task<InjectionMold?> GetById(Guid moldId);

        Task<IEnumerable<InjectionMold>?> GetAll();
    }
}
