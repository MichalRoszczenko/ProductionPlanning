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
            => await _dbContext.Productions.ToListAsync();
    }
}
