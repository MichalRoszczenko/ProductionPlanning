using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Production.Domain.Entities;

namespace Production.Infrastructure.Persistence.Configurations
{
	public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
	{
		public void Configure(EntityTypeBuilder<Ingredient> builder)
		{
			builder.Property(i => i.Name).IsRequired();
		}
	}
}
