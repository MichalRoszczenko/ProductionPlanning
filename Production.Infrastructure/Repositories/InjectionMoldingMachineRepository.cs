using Microsoft.EntityFrameworkCore;
using Production.Domain.Entities;
using Production.Domain.Interfaces;
using Production.Infrastructure.Persistence;

namespace Production.Infrastructure.Repositories
{
    public class InjectionMoldingMachineRepository : IInjectionMoldingMachineRepository
    {
        private readonly ProductionDbContext _dbContext;

        public InjectionMoldingMachineRepository(ProductionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task Create(InjectionMoldingMachine injectionMachine)
        {
            await _dbContext.AddAsync(injectionMachine);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<InjectionMoldingMachine>> GetAll()
        {
            var machines = await _dbContext.InjectionMoldingMachines.ToListAsync();

            return machines;
        }

        public async Task<InjectionMoldingMachine?> GetById(int machineId)
        {
            var machine = await _dbContext.InjectionMoldingMachines.FirstOrDefaultAsync(p => p.Id == machineId);

            return machine;
        }

        public async Task Remove(int machineId)
        {
            var machine = await GetById(machineId);
            _dbContext.InjectionMoldingMachines.Remove(machine!);
            _dbContext.SaveChanges();
        }
    }
}
