using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Production.Infrastructure.Persistence.Configurations
{
	public class ProductionConfiguration : IEntityTypeConfiguration<Domain.Entities.Production>
	{
		public void Configure(EntityTypeBuilder<Domain.Entities.Production> builder)
		{
			builder.Property(p => p.Start)
				.IsRequired();

			builder.Property(p => p.End)
				.IsRequired();

			builder.Property(e => e.InjectionMoldId)
				.IsRequired();

			builder.Property(e => e.InjectionMoldingMachineId)
				.IsRequired();

			builder.HasOne(m => m.InjectionMold)
			.WithMany(p => p.Productions)
			.HasForeignKey(f => f.InjectionMoldId);

			builder.HasOne(m => m.InjectionMoldingMachine)
			.WithMany(p => p.Productions)
			.HasForeignKey(f => f.InjectionMoldingMachineId);

			builder.OwnsOne(m => m.MaterialStatus);
		}
	}
}
