using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Production.Domain.Entities;

namespace Production.Infrastructure.Persistence.Configurations
{
	public class MaterialConfiguration : IEntityTypeConfiguration<Material>
	{
		public void Configure(EntityTypeBuilder<Material> builder)
		{
			builder.Property(m => m.Name).IsRequired().HasColumnType("varchar(50)");

			builder.Property(m => m.Description).HasMaxLength(200);

			builder.Property(m => m.Cost).HasColumnType("decimal(5,2)").IsRequired();

			builder.OwnsOne(m => m.Stock);
		}
	}
}
