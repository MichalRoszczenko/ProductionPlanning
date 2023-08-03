using Microsoft.EntityFrameworkCore;
using Production.Domain.Interfaces;
using Production.Infrastructure.Assign;
using Production.Infrastructure.Persistence;

namespace Production.Infrastructure.Repositories
{
    public class ProductionRepository : IProductionRepository
    {
        private readonly ProductionDbContext _dbContext;
        private readonly IAssignProduction _assignProduction;

        public ProductionRepository(ProductionDbContext dbContext, IAssignProduction assignProduction)
        {
            _dbContext = dbContext;
            _assignProduction = assignProduction;
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
            var assignedProduction = await _assignProduction.AssignProductionById(production);

            await _dbContext.Productions.AddAsync(assignedProduction);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Remove(Domain.Entities.Production production)
        {
            _dbContext.Productions.Remove(production);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Commit() => await _dbContext.SaveChangesAsync();

    }
}