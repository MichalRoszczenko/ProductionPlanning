namespace Production.Application.Interfaces
{
    public interface IDatabaseService<T, Y>
        where T : class
        where Y : struct
    {
        Task Create(T itemDto);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Y itemId, bool withProductionInfo = false);
        Task Remove(Y itemId);
        Task Update(Y itemId, T itemDto);
    }
}