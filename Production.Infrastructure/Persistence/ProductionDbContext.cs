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
            modelBuilder.Entity<Domain.Entities.Production>(etb =>
            {
                etb.Property(p => p.Start).IsRequired();

                etb.Property(p => p.End).IsRequired();

                etb.HasOne(m => m.InjectionMold)
                .WithMany(p => p.Productions)
                .HasForeignKey(f => f.InjectionMoldId);

                etb.HasOne(m => m.InjectionMoldingMachine)
                .WithMany(p => p.Productions)
                .HasForeignKey(f => f.InjectionMoldingMachineId);
            });

            modelBuilder.Entity<InjectionMold>(etb =>
            {
                etb.Property(m => m.Name).IsRequired()
                .HasColumnType("varchar(50)")
                .HasMaxLength(30);

                etb.HasMany(i => i.Ingredients)
                .WithOne(m => m.InjectionMold)
                .HasForeignKey(s => s.InjectionMoldId);

                etb.HasOne(m => m.Material)
                .WithOne(i => i.InjectionMold)
                .HasForeignKey<InjectionMold>(f => f.MaterialId);

                etb.Property(m => m.Consumption).HasColumnType("decimal(4,2)");
            });


            modelBuilder.Entity<InjectionMoldingMachine>(etb =>
            {
                etb.Property(m => m.Name).IsRequired()
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Material>(etb =>
            {
                etb.Property(m => m.Name).IsRequired().HasColumnType("varchar(50)");

                etb.Property(m => m.Description).HasMaxLength(200);

                etb.Property(m => m.Cost).HasColumnType("decimal(5,2)").IsRequired();

                etb.OwnsOne(m => m.Stock);
            });

            modelBuilder.Entity<Ingredient>()
                .Property(i => i.Name).IsRequired();
        }
    }
}
