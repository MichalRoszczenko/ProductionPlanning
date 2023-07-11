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

        public async Task Create(Domain.Entities.Production production)
        {
            var assignedProduction = await _assignProduction.AssignProductionById(production);

            await _dbContext.Productions.AddAsync(assignedProduction);
            _dbContext.SaveChanges();
        }
    }
}
