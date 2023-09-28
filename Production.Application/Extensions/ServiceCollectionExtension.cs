using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Production.Application.Builders;
using Production.Application.Dtos;
using Production.Application.Interfaces;
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
            services.AddScoped<IDatabaseCrudService<ProductionDto, int>, ProductionService>();
            services.AddScoped<IDatabaseCrudService<InjectionMoldingMachineDto,int>, InjectionMoldingMachineService>();
            services.AddScoped<IDatabaseCrudService<InjectionMoldDto,Guid>, InjectionMoldService>();
            services.AddScoped<IDatabaseCrudService<MaterialDto, int>, MaterialService>();
            services.AddScoped<IProductionBuilder, ProductionBuilder>();
            services.AddScoped<IMaterialInventoryHandler, MaterialInventoryHandler>();
            services.AddAutoMapper(typeof(ProductionMappingProfile));

            services.AddValidatorsFromAssemblyContaining<ProductionDtoValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}
