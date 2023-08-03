using Microsoft.EntityFrameworkCore;
using Production.Domain.Entities;
using Production.Domain.Interfaces;
using Production.Infrastructure.Persistence;

namespace Production.Infrastructure.Repositories
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly ProductionDbContext _dbContext;

        public MaterialRepository(ProductionDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Material>> GetAll()
        {
            var materials = await _dbContext.Materials.ToListAsync();

            return materials;
        }
    }
}
