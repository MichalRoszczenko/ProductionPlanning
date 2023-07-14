using Production.Domain.Interfaces;
using Production.Application.Production;
using AutoMapper;

namespace Production.Application.Services
{
    public interface IProductionService
    {
        Task<IEnumerable<ProductionDtoOutput>> GetAll();
        Task Create(ProductionDtoInput productionDto);
        Task Remove(int productionId);
    }

    public class ProductionService : IProductionService
    {
        private readonly IProductionRepository _productionRepository;
        private readonly IMapper _mapper;

        public ProductionService(IProductionRepository productionRepository, IMapper mapper)
        {
            _productionRepository = productionRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductionDtoOutput>> GetAll()
        {
            var production = await _productionRepository.GetAll();

            var productionDto = _mapper.Map<IEnumerable<ProductionDtoOutput>>(production);

            return productionDto;
        }

        public async Task Create(ProductionDtoInput productionDto)
        {
            var production = _mapper.Map<Domain.Entities.Production>(productionDto);

            production.ProductionTimeCalculation();

            await _productionRepository.Create(production);
        }

        public async Task Remove(int productionId)
        {
            var productions = await _productionRepository.GetAll();
            var production = productions.FirstOrDefault(p => p.Id == productionId);

            await _productionRepository.Remove(production!);
        }
    }
}
