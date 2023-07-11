using Microsoft.EntityFrameworkCore;
using Production.Domain.Entities;
using Production.Domain.Interfaces;
using Production.Infrastructure.Persistence;

namespace Production.Infrastructure.Repositories
{
    public class InjectionMoldRepository : IInjectionMoldRepository
    {
        private readonly ProductionDbContext _dbContext;

        public InjectionMoldRepository(ProductionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<InjectionMold?> GetById(Guid moldId)
        {
            var injecitonMold = await _dbContext.InjectionMolds.FirstOrDefaultAsync(x => x.Id == moldId);

            return injecitonMold;
        }
    }
}
