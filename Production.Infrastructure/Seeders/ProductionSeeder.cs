using Microsoft.EntityFrameworkCore;
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
                if(_dbContext.Database.IsSqlServer())
                {
                    if (!_dbContext.Productions.Any())
                    {
                        var production = CreateProduction();
                        _dbContext.Productions.Add(production);
                        await _dbContext.SaveChangesAsync();
                    }
                }
            }
        }

        private Domain.Entities.Production CreateProduction()
        {
            var production = new Domain.Entities.Production()
            {
                Start = DateTime.Now,
                End = DateTime.Now.AddDays(1),
                InjectionMold = new InjectionMold()
                {
                    Name = "SeededInjectionMold",
                    Producer = "SeededProducer",
                    Size = "small",
                    Consumption = 5,
                    Material = new Material
                    {
                        Name = "MaterialSeeded",
                        Type = "PP",
                        Cost = 15,
                        Description = "Seeded Material",
                        Stock = new MaterialStock()
                        {
                            MaterialInStock = 300,
                            PlannedMaterialDemand = 125
                        }
                    }
                },
                InjectionMoldingMachine = new InjectionMoldingMachine()
                {
                    Name = "SeededMachine",
                    Size = "small",
                    Online = true,
                    Tonnage = 150
                },
                MaterialStatus = new MaterialStatus()
                {
                    MaterialIsAvailable = true,
                    MaterialUsage = 125
                }
            };

            production.ProductionTimeCalculation();

            return production;
        }
    }
}
