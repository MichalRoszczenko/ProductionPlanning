using Production.Application.Builders;
using Production.Domain.Entities;

namespace Production.Application.Interfaces
{
    internal interface IProductionBuilder
    {
        ProductionBuilder AddMaterialStatus(InjectionMold injectionMold, Material material);
        Domain.Entities.Production Build();
        ProductionBuilder CalculateProductionTime();
        ProductionBuilder Init(Domain.Entities.Production production);
		ProductionBuilder RemoveMaterialDemands(InjectionMold injectionMold, Material material);
	}
}