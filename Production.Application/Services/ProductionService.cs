using Production.Domain.Interfaces;
using AutoMapper;
using Production.Application.Productions;

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
        private readonly IProductionInventoryService _productionChecker;
        private readonly IMapper _mapper;

        public ProductionService(IProductionRepository productionRepository, IMapper mapper,
            IProductionInventoryService productionChecker)
        {
            _productionRepository = productionRepository;
            _mapper = mapper;
            _productionChecker = productionChecker;
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

            var materialIsScheduled = await _productionChecker.IsMaterialInStock(production);

            production.MaterialIsRdy = materialIsScheduled;

            await _productionRepository.Create(production);
        }

        public async Task Remove(int productionId)
        {
            var production = await _productionRepository.GetById(productionId);

            await _productionChecker.HandOverMaterial(production);

            await _productionRepository.Remove(production!);
        }

        public async Task Update(int productionId, ProductionDto productionDto)
        {
            var productions = await _productionRepository.GetAll();

            var production = productions.FirstOrDefault(p => p.Id == productionId);

            production!.Start = productionDto.Start;
            production.End = productionDto.End;
            production.InjectionMoldingMachineId = productionDto.InjectionMoldingMachineId;
            production.InjectionMoldId = productionDto.InjectionMoldId;
            production.ProductionTimeCalculation();

            await _productionRepository.Commit();
        }
    }
}
