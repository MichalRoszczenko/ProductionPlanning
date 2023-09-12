using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Production.Domain.Entities;

namespace Production.Infrastructure.Persistence.Configurations
{
	public class InjectionMoldConfiguration : IEntityTypeConfiguration<InjectionMold>
	{
		public void Configure(EntityTypeBuilder<InjectionMold> builder)
		{
			builder.Property(m => m.Name).IsRequired()
				.HasColumnType("varchar(50)")
				.HasMaxLength(30);

			builder.HasMany(i => i.Ingredients)
			.WithOne(m => m.InjectionMold)
			.HasForeignKey(s => s.InjectionMoldId);

			builder.HasOne(m => m.Material)
			.WithOne(i => i.InjectionMold)
			.HasForeignKey<InjectionMold>(f => f.MaterialId)
			.OnDelete(DeleteBehavior.SetNull);

			builder.Property(m => m.Consumption).HasColumnType("decimal(4,2)");
		}
	}
}
