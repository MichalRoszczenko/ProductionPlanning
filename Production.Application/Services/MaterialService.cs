using AutoMapper;
using Production.Application.Material;
using Production.Domain.Interfaces;

namespace Production.Application.Services
{
    public interface IMaterialService
    {
        Task<IEnumerable<MaterialDto>> GetAll();
    }

    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepository _repository;
        private readonly IMapper _mapper;

        public MaterialService(IMaterialRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<MaterialDto>> GetAll()
        {
            var materials = await _repository.GetAll();
            var materialsDto = _mapper.Map<IEnumerable<MaterialDto>>(materials);
            return materialsDto;
        }
    }
}
