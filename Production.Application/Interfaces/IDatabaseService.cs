namespace Production.Application.Interfaces
{
    public interface IDatabaseService<TItemDto, YitemId>
        where TItemDto : class
        where YitemId : struct
    {
        Task Create(TItemDto itemDto);
        Task<IEnumerable<TItemDto>> GetAll();
        Task<TItemDto> GetById(YitemId itemId);
        Task Remove(YitemId itemId);
        Task Update(YitemId itemId, TItemDto itemDto);
    }
}