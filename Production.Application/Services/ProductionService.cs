using Production.Domain.Interfaces;
using AutoMapper;
using Production.Application.Productions;
using Production.Domain.Entities;

namespace Production.Application.Services
{
    public interface IProductionService
    {
        Task<IEnumerable<ProductionDto>> GetAll();
        Task<ProductionDto> GetById(int id);
        Task Create(ProductionDto productionDto);
        Task Remove(int productionId);
        Task Update(int productionId, ProductionDto productionDto);
    }

    public class ProductionService : IProductionService
    {
        private readonly IProductionRepository _productionRepository;
        private readonly IProductionInventoryService _inventoryService;
        private readonly IMapper _mapper;

        public ProductionService(IProductionRepository productionRepository, IMapper mapper,
            IProductionInventoryService inventoryService)
        {
            _productionRepository = productionRepository;
            _mapper = mapper;
            _inventoryService = inventoryService;
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

            production.ProductionTimeCalculation();

            var materialStatusDto = await _inventoryService.AddMaterialReservation(production);

            var materialStatus = _mapper.Map<MaterialStatus>(materialStatusDto);

            production.MaterialStatus = materialStatus;

            await _productionRepository.Create(production);
        }

        public async Task Remove(int productionId)
        {
            var production = await _productionRepository.GetById(productionId);

            await _productionRepository.Remove(production!);

            if(production.InjectionMold.MaterialId != null)
            {
                await _inventoryService.RemoveMaterialReservation(production);
            }
        }

        public async Task Update(int productionId, ProductionDto productionDto)
        {
            var productions = await _productionRepository.GetAll();
            var production = productions.First(p => p.Id == productionId);

            await _inventoryService.RemoveMaterialReservation(production);

			PassDtoToProduction(production, productionDto);

			var materialStatusDto = await _inventoryService.AddMaterialReservation(production);

            var materialStatus = _mapper.Map<MaterialStatus>(materialStatusDto);
            production.MaterialStatus = materialStatus;

            await _productionRepository.Commit();
        }

        private void PassDtoToProduction(Domain.Entities.Production production, ProductionDto dto)
        {
			production!.Start = dto.Start;
			production.End = dto.End;
			production.InjectionMoldingMachineId = dto.InjectionMoldingMachineId;
			production.InjectionMoldId = dto.InjectionMoldId;
			production.MaterialStatus.MaterialUsage = dto.MaterialUsage;
			production.MaterialStatus.MaterialIsAvailable = dto.MaterialIsAvailable;
			production.ProductionTimeCalculation();
		}
    }
}