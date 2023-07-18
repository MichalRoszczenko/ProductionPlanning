using Production.Domain.Interfaces;
using AutoMapper;
using Production.Application.Productions;

namespace Production.Application.Services
{
    public interface IProductionService
    {
        Task<IEnumerable<ProductionDtoOutput>> GetAll();
        Task<ProductionDtoInput> GetById(int id);
        Task Create(ProductionDtoInput productionDto);
        Task Remove(int productionId);
        Task Update(int productionId, ProductionDtoInput productionDto);
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
        public async Task<ProductionDtoInput> GetById(int id)
        {
            var productions = await _productionRepository.GetAll();

            var production = productions.FirstOrDefault(p => p.Id == id);

            var productionDto = _mapper.Map<ProductionDtoInput>(production);

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

        public async Task Update(int productionId, ProductionDtoInput productionDto)
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
