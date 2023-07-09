using Microsoft.Extensions.DependencyInjection;
using Production.Application.Mappings;
using Production.Application.Services;

namespace Production.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IProductionService, ProductionService>();
            services.AddAutoMapper(typeof(ProductionMappingProfile));
        }
    }
}
