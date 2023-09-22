using Production.Application.Dtos;
using Production.Application.Interfaces;
using Production.Domain.Entities;

namespace Production.Application.Builders
{
    internal sealed class ProductionBuilder : IProductionBuilder
	{
		private Domain.Entities.Production _production { get; set; }

		public ProductionBuilder Init(Domain.Entities.Production production)
		{
			_production = production;
			return this;
		}

		public ProductionBuilder CalculateProductionTime()
		{
			_production.ProductionTimeCalculation();
			return this;
		}

		public ProductionBuilder AddMaterialStatus(InjectionMold injectionMold, Material material)
		{
			var materialRequirements = CreateMaterialRequirements(injectionMold);

			material.Stock.PlannedMaterialDemand += materialRequirements.Usage;

			material.Stock.CountMaterialToOrder();

			_production.MaterialStatus.MaterialIsAvailable = material.Stock.PlannedMaterialDemand <= material.Stock.MaterialInStock;
			_production.MaterialStatus.MaterialUsage = materialRequirements.Usage;

			return this;
		}

		private MaterialRequirements CreateMaterialRequirements(InjectionMold injectionMold)
		{
			var consumption = injectionMold!.Consumption;

			var productionTime = _production.ProductionTimeInHours;

			return new MaterialRequirements(productionTime, consumption);
		}

		public Domain.Entities.Production Build()
		{
			return _production;
		}
	}
}