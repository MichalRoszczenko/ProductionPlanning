using Production.Domain.Entities;
using Production.Infrastructure.Persistence;

namespace Production.Infrastructure.Seeders
{
    public class ProductionSeeder
    {
        private readonly ProductionDbContext _dbContext;

        public ProductionSeeder(ProductionDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Seed()
        {
            if(await _dbContext.Database.CanConnectAsync())
            {
                if(!_dbContext.Productions.Any())
                {
                    var production = CreateProduction();
                    _dbContext.Productions.Add(production);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }

        private Domain.Entities.Production CreateProduction()
        {
            var production = new Domain.Entities.Production()
            {
                Start = DateTime.Now,
                End = DateTime.Now.AddDays(5),
                InjectionMold = new InjectionMold()
                {
                    Name = "Tigre",
                    Producer = "Philips",
                    Size = "small",
                },
                InjectionMoldingMachine = new InjectionMoldingMachine()
                {
                    Name = "Engel",
                    Size = "small",
                    Online = true,
                    Tonnage = 150
                }
            };

            production.ProductionTimeCalculation();

            return production;
        }
    }
}
