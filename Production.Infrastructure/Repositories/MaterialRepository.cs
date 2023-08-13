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
        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Material>> GetAll()
        {
            var materials = await _dbContext.Materials.ToListAsync();

            return materials;
        }

        public async Task<Material> GetById(int materialId)
        {
            var material = await _dbContext
                .Materials
                .Include(n =>n.Stock)
                .FirstOrDefaultAsync(p => p.Id == materialId);

            return material!;
        }

        public async Task<Material> GetByMoldId(Guid moldId)
        {
            var material = await _dbContext
                .Materials
                .Include(f => f.InjectionMold)
                .Include(n => n.Stock)
                .FirstOrDefaultAsync(p => p.InjectionMold.Id == moldId);

            return material!;
        }

        public async Task Create(Material material)
        {
            await _dbContext.Materials.AddAsync(material);
            _dbContext.SaveChanges();
        }
    }
}
