using Microsoft.EntityFrameworkCore;
using Production.Domain.Interfaces;
using Production.Infrastructure.Persistence;

namespace Production.Infrastructure.Repositories
{
    public class ProductionRepository : IProductionRepository
    {
        private readonly ProductionDbContext _dbContext;

        public ProductionRepository(ProductionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Domain.Entities.Production>> GetAll() 
            => await _dbContext.Productions
            .Include(s => s.InjectionMold)
            .Include(s => s.InjectionMoldingMachine)
            .ToListAsync();

        public async Task<Domain.Entities.Production> GetById(int productionId)
        {
            var production = await _dbContext.Productions
                .Include(s => s.InjectionMold)
                .Include(s => s.InjectionMoldingMachine)
                .FirstOrDefaultAsync(s => s.Id == productionId);

            return production!;
        }

        public async Task Create(Domain.Entities.Production production)
        {
            var assignedProduction = await AssignProductionById(production);

            await _dbContext.Productions.AddAsync(assignedProduction);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Remove(Domain.Entities.Production production)
        {
            _dbContext.Productions.Remove(production);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Commit() => await _dbContext.SaveChangesAsync();

        private async Task<Domain.Entities.Production> AssignProductionById(Domain.Entities.Production production)
        {
            production.InjectionMoldingMachine = await _dbContext.InjectionMoldingMachines
                .FirstAsync(x => x.Id == production.InjectionMoldingMachineId);

            production.InjectionMold = await _dbContext.InjectionMolds
                .FirstAsync(x => x.Id == production.InjectionMoldId);

            return production;
        }
    }
}