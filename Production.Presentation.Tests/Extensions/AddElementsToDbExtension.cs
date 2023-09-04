using Microsoft.AspNetCore.Mvc.Testing;
using Production.Infrastructure.Persistence;

namespace Production.Presentation.Tests.Extensions
{
	public static class AddElementsToDbExtension
	{
		public static async Task AddElementToDb<T>(this WebApplicationFactory<Program> factory, T item)
		where T : class
		{
			var scopeFactory = factory.Services.GetService<IServiceScopeFactory>();
			var scope = scopeFactory!.CreateScope();
			var dbContext = scope.ServiceProvider.GetRequiredService<ProductionDbContext>();

			await dbContext.AddAsync(item!);
			
			await dbContext.SaveChangesAsync();
		}

		public static async Task AddElementsToDb<T>(this WebApplicationFactory<Program> factory, List<T> items)
			where T : class
		{
			var scopeFactory = factory.Services.GetService<IServiceScopeFactory>();
			var scope = scopeFactory!.CreateScope();
			var dbContext = scope.ServiceProvider.GetRequiredService<ProductionDbContext>();

			foreach (var item in items)
			{
				await dbContext.AddAsync(item!);
			}

			await dbContext.SaveChangesAsync();
		}

		public static async Task AddElementsToDb<T,Y>(this WebApplicationFactory<Program> factory, List<T> items, List<Y> items2)
			where T : class
			where Y : class
		{
			var scopeFactory = factory.Services.GetService<IServiceScopeFactory>();
			var scope = scopeFactory!.CreateScope();
			var dbContext = scope.ServiceProvider.GetRequiredService<ProductionDbContext>();

			foreach (var item in items)
			{
				await dbContext.AddAsync(item!);
			}

			foreach (var item2 in items2)
			{
				await dbContext.AddAsync(item2!);
			}

			await dbContext.SaveChangesAsync();
		}
	}
}
