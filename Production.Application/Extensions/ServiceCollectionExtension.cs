using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Production.Application.Dtos;
using Production.Application.Interfaces;
using Production.Application.InventoryHandlers;
using Production.Application.InventoryHandling;
using Production.Application.Mappings;
using Production.Application.Services;
using Production.Application.Validators;

namespace Production.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IProductionService, ProductionService>();
            services.AddScoped<IDatabaseService<InjectionMoldingMachineDto,int>, InjectionMoldingMachineService>();
            services.AddScoped<IDatabaseService<InjectionMoldDto,Guid>, InjectionMoldService>();
            services.AddScoped<IDatabaseService<MaterialDto, int>, MaterialService>();
            services.AddScoped<IProductionInventoryHandler, ProductionInventoryHandler>();
            services.AddScoped<IMaterialInventoryHandler, MaterialInventoryHandler>();
            services.AddAutoMapper(typeof(ProductionMappingProfile));

            services.AddValidatorsFromAssemblyContaining<ProductionDtoValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}
