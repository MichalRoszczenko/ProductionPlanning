using AutoMapper;
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
    }
}
