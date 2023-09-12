using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Production.Domain.Entities;

namespace Production.Infrastructure.Persistence.Configurations
{
	public class InjectionMoldingMachineConfiguration : IEntityTypeConfiguration<InjectionMoldingMachine>
	{
		public void Configure(EntityTypeBuilder<InjectionMoldingMachine> builder)
		{
			builder.Property(m => m.Name).IsRequired()
						.HasColumnType("varchar(50)");
		}
	}
}
