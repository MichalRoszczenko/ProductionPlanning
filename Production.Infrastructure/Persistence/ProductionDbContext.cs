using Microsoft.EntityFrameworkCore;
using Production.Domain.Entities;

namespace Production.Infrastructure.Persistence
{
    public class ProductionDbContext : DbContext
    {
        public ProductionDbContext(DbContextOptions<ProductionDbContext> options) : base(options) 
        {
        }

        public DbSet<Domain.Entities.Production> Productions { get; set; }
        public DbSet<InjectionMold> InjectionMolds { get; set; }
        public DbSet<InjectionMoldingMachine> InjectionMoldingMachines { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
