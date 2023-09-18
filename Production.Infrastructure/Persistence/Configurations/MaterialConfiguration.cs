using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Production.Domain.Entities;

namespace Production.Infrastructure.Persistence.Configurations
{
	public class MaterialConfiguration : IEntityTypeConfiguration<Material>
	{
		public void Configure(EntityTypeBuilder<Material> builder)
		{
			builder.Property(m => m.Name)
				.IsRequired()
				.HasColumnType("varchar(15)")
				.HasMaxLength(15);
			
			builder.Property(m => m.Type)
				.IsRequired()
				.HasColumnType("varchar(15)")
				.HasMaxLength(15);

			builder.Property(m => m.Description)
				.IsRequired()
				.HasColumnType("varchar(32)")
				.HasMaxLength(32);

			builder.Property(m => m.Cost)
				.IsRequired()
				.HasColumnType("decimal(5,2)");

			builder.OwnsOne(m => m.Stock);
		}
	}
}
