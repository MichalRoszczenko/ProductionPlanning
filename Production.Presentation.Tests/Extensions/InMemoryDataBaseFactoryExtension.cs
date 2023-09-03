using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Production.Infrastructure.Persistence;

namespace Production.Presentation.Tests.Extensions
{
	public static class InMemoryDataBaseFactoryExtension
	{
		public static WebApplicationFactory<Program> CreateInMemoryDatabase(this WebApplicationFactory<Program> factory)
		{
			var inMemoryFactory = factory.WithWebHostBuilder(builder
				=> builder.ConfigureServices(cfg =>
				{
					var dbContext = cfg.FirstOrDefault(ser
					=> ser.ServiceType == typeof(DbContextOptions<ProductionDbContext>));

					cfg.Remove(dbContext!);

					cfg.AddDbContext<ProductionDbContext>(opt => opt.UseInMemoryDatabase("TestProduction"));
				}));

			return inMemoryFactory;
		}
	}
}
