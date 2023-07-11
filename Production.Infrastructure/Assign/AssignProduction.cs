using Microsoft.EntityFrameworkCore;
using Production.Domain.Entities;
using Production.Infrastructure.Persistence;

namespace Production.Infrastructure.Assign
{
    public interface IAssignProduction
    {
        Task<Domain.Entities.Production> AssignProductionById(Domain.Entities.Production production);
    }

    public class AssignProduction : IAssignProduction
    {
        private readonly ProductionDbContext _dbContext;

        public AssignProduction(ProductionDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Domain.Entities.Production> AssignProductionById(Domain.Entities.Production production)
        {
            production.InjectionMoldingMachine = await AssignMachine(production.InjectionMoldingMachineId);
            production.InjectionMold = await AssignMold(production.InjectionMoldId);

            return production;
        }
        private async Task<InjectionMold> AssignMold(Guid injectionMoldId)
            => await _dbContext.InjectionMolds.FirstOrDefaultAsync(x => x.Id == injectionMoldId);

        private async Task<InjectionMoldingMachine> AssignMachine(int injectionMoldingMachineId)
            => await _dbContext.InjectionMoldingMachines.FirstOrDefaultAsync(x => x.Id == injectionMoldingMachineId);
    }
}
