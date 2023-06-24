using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Production.Infrastructure.Persistence;

namespace Production.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProductionDbContext>(opt
                => opt.UseSqlServer(configuration.GetConnectionString("Planning")));
        }
    }
}
