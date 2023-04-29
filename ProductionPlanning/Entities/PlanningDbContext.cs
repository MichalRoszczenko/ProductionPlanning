using Microsoft.EntityFrameworkCore;

namespace ProductionPlanning.Entities
{
    public class PlanningDbContext : DbContext
    {
        public PlanningDbContext(DbContextOptions<PlanningDbContext> options) : base(options)
        {
            
        }

        public DbSet<Production> Productions { get; set; }
        public DbSet<InjectionMold> InjectionMolds { get; set; }
        public DbSet<InjectionMoldingMachine> InjectionMoldingMachines { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

    }
}
