using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Production.Application.Mappings;
using Production.Application.Productions.Validators;
using Production.Application.Services;

namespace Production.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IProductionService, ProductionService>();
            services.AddScoped<IInjectionMoldService, InjectionMoldService>();
            services.AddScoped<IInjectionMoldingMachineService, InjectionMoldingMachineService>();
            services.AddAutoMapper(typeof(ProductionMappingProfile));

            services.AddValidatorsFromAssemblyContaining<ProductionDtoValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}
