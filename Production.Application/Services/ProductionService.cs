using Production.Domain.Interfaces;
using AutoMapper;
using Production.Application.Dtos;
using Production.Application.Interfaces;

namespace Production.Application.Services
{
    internal sealed class ProductionService : IDatabaseCrudService<ProductionDto, int>
	{
		private readonly IProductionRepository _productionRepository;
		private readonly IProductionBuilder _productionBuilder;
		private readonly IInjectionMoldRepository _injectionMoldRepository;
		private readonly IMaterialRepository _materialRepository;
		private readonly IMaterialInventoryHandler _materialInventoryHandler;
		private readonly IMapper _mapper;

		public ProductionService(IProductionRepository productionRepository, IMaterialRepository materialRepository, 
			IInjectionMoldRepository injectionMoldRepository, IProductionBuilder productionBuilder,
			IMaterialInventoryHandler materialInventoryHandler, IMapper mapper)
		{
			_productionRepository = productionRepository;
			_materialRepository = materialRepository;
			_injectionMoldRepository = injectionMoldRepository;
			_productionBuilder = productionBuilder;
			_materialInventoryHandler = materialInventoryHandler;
			_mapper = mapper;
		}
		public async Task<IEnumerable<ProductionDto>> GetAll()
		{
			var production = await _productionRepository.GetAll();

			var productionDto = _mapper.Map<IEnumerable<ProductionDto>>(production);

			return productionDto;
		}
		public async Task<ProductionDto> GetById(int id)
		{
			var production = await _productionRepository.GetById(id);

			var productionDto = _mapper.Map<ProductionDto>(production);

			return productionDto;
		}

		public async Task Create(ProductionDto productionDto)
		{
			var production = _mapper.Map<Domain.Entities.Production>(productionDto);
			var mold = await _injectionMoldRepository.GetById(production.InjectionMoldId);
			var material = await _materialRepository.GetByMoldId(production.InjectionMoldId);

			var productionToCreate = _productionBuilder.Init(production)
				.CalculateProductionTime()
				.AddMaterialStatus(mold!, material)
				.Build();

			await _productionRepository.Create(productionToCreate);
		}

		public async Task Remove(int productionId)
		{
			var production = await _productionRepository.GetById(productionId);
			var mold = await _injectionMoldRepository.GetById(production.InjectionMoldId);
			var material = await _materialRepository.GetByMoldId(production.InjectionMoldId);

			var productionToRemove = _productionBuilder
				.Init(production)
				.CalculateProductionTime()
				.RemoveMaterialDemands(mold!, material)
				.Build();

			await _productionRepository.Remove(productionToRemove);

			if (mold!.MaterialId != null)
			{
				await _materialInventoryHandler.CalculateDemands(material);
			}
		}

		public async Task Update(int productionId, ProductionDto productionDto)
		{
			var production = await _productionRepository.GetById(productionId);
			var mold = await _injectionMoldRepository.GetById(production.InjectionMoldId);
			var material = await _materialRepository.GetByMoldId(production.InjectionMoldId);

			_productionBuilder
				.Init(production)
				.CalculateProductionTime()
				.RemoveMaterialDemands(mold!, material)
				.UpdateProduction(productionDto)
				.AddMaterialStatus(mold!,material)
				.Build();

			await _productionRepository.Commit();
		}
	}
}