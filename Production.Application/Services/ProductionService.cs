using Production.Domain.Interfaces;
using Production.Application.Production;
using AutoMapper;

namespace Production.Application.Services
{
    public interface IProductionService
    {
        Task<IEnumerable<ProductionDto>> GetAll();
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
        public async Task<IEnumerable<ProductionDto>> GetAll()
        {
            var production = await _productionRepository.GetAll();

            var productionDto = _mapper.Map<IEnumerable<ProductionDto>>(production);

            return productionDto;
        }
    }
}
