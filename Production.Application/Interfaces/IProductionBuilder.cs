using Production.Application.Builders;
using Production.Application.Dtos;
using Production.Domain.Entities;

namespace Production.Application.Interfaces
{
    internal interface IProductionBuilder
	{
		ProductionBuilder Init(Domain.Entities.Production production);
		ProductionBuilder CalculateProductionTime();
		ProductionBuilder AddMaterialStatus(InjectionMold injectionMold, Material material);
		ProductionBuilder UpdateProduction(ProductionDto dto);
		ProductionBuilder RemoveMaterialDemands(InjectionMold injectionMold, Material material);
		Domain.Entities.Production Build();
	}
}