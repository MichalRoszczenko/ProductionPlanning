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

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task Create(InjectionMold injectionMold)
        {
            injectionMold.Material = await _dbContext.Materials.FirstAsync(x => x.Id == injectionMold.MaterialId);

            _dbContext.InjectionMolds.Add(injectionMold);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<InjectionMold>?> GetAll()
        {
            var molds = await _dbContext.InjectionMolds.ToListAsync();

            return molds;
        }

        public async Task<InjectionMold?> GetById(Guid moldId, bool withProductionInfo = false)
        {
            if(withProductionInfo)
            {
                var extendedInjecitonMold = await _dbContext.InjectionMolds
                 .Include(n => n.Productions!
                 .Where(p => p.InjectionMoldId == moldId))
                 .FirstOrDefaultAsync(x => x.Id == moldId);

                return extendedInjecitonMold;
            }
            else return await _dbContext.InjectionMolds.FirstOrDefaultAsync(x => x.Id == moldId);
        }

        public async Task Remove(Guid moldId)
        {
            var mold = await GetById(moldId);

            _dbContext.InjectionMolds.Remove(mold!);

            _dbContext.SaveChanges();
        }
    }
}
