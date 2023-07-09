using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Production.Domain.Interfaces;
using Production.Infrastructure.Persistence;
using Production.Infrastructure.Repositories;
using Production.Infrastructure.Seeders;

namespace Production.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProductionDbContext>(opt
                => opt.UseSqlServer(configuration.GetConnectionString("Planning")));

            services.AddScoped<ProductionSeeder>();

            services.AddScoped<IProductionRepository, ProductionRepository>();
        }
    }
}
