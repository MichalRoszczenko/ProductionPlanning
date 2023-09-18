using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Production.Domain.Entities;

namespace Production.Infrastructure.Persistence.Configurations
{
	public class InjectionMoldingMachineConfiguration : IEntityTypeConfiguration<InjectionMoldingMachine>
	{
		public void Configure(EntityTypeBuilder<InjectionMoldingMachine> builder)
		{
			builder.Property(m => m.Name)
				.IsRequired()
				.HasColumnType("varchar(15)")
				.HasMaxLength(15);

			builder.Property(m => m.Tonnage)
				.IsRequired()
				.HasColumnType("int");

			builder.Property(m => m.Size)
				.IsRequired()
				.HasColumnType("varchar(15)")
				.HasMaxLength(15);
		}
	}
}
