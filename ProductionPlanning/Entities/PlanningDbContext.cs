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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Production>(etb =>
            {
                etb.Property(p=>p.Start).IsRequired();
                etb.Property(p=> p.End).IsRequired();
            });

            modelBuilder.Entity<InjectionMold>()
                .Property(m => m.Name).IsRequired()
                .HasColumnType("varchar(50)")
                .HasMaxLength(30);

            modelBuilder.Entity<InjectionMoldingMachine>(etb =>
            {
                etb.Property(m => m.Name).IsRequired()
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Material>(etb =>
            {
                etb.Property(m => m.Name).IsRequired().HasColumnType("varchar(50)");
                etb.Property(m => m.Description).HasMaxLength(200);
                etb.Property(m => m.Cost).HasColumnType("decimal(5,2").IsRequired();
            });

            modelBuilder.Entity<Ingredient>()
                .Property(i => i.Name).IsRequired();
        }
    }
}
