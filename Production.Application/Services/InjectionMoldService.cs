using AutoMapper;
using Production.Application.InjectionMolds;
using Production.Domain.Entities;
using Production.Domain.Interfaces;

namespace Production.Application.Services
{
    public interface IInjectionMoldService
    {
        Task<IEnumerable<InjectionMoldDto>> GetAll();
        Task Create(InjectionMoldDto moldDto);
        Task<InjectionMoldDto> GetById(Guid moldId, bool withProductionInfo = false);
        Task Update(Guid moldId, InjectionMoldDto moldDto);
        Task Remove(Guid moldId);
    }

    public class InjectionMoldService : IInjectionMoldService
    {
        private readonly IInjectionMoldRepository _moldRepository;
        private readonly IMapper _mapper;
        private readonly IMaterialRepository _materialRepository;

        public InjectionMoldService(IInjectionMoldRepository moldRepository, IMapper mapper,
            IMaterialRepository materialRepository)
        {
            _moldRepository = moldRepository;
            _mapper = mapper;
            _materialRepository = materialRepository;
        }

        public async Task<IEnumerable<InjectionMoldDto>> GetAll()
        {
            var molds = await _moldRepository.GetAll();
            var dto = _mapper.Map<IEnumerable<InjectionMoldDto>>(molds);

            return dto;
        }

        public async Task<InjectionMoldDto> GetById(Guid moldId, bool withProductionInfo = false)
        {
            var mold = await _moldRepository.GetById(moldId, withProductionInfo);
            var dto = _mapper.Map<InjectionMoldDto>(mold);

            return dto;
        }

        public async Task Create(InjectionMoldDto moldDto)
        {
            var mold = _mapper.Map<InjectionMold>(moldDto);
            await _moldRepository.Create(mold);
        }

        public async Task Update(Guid moldId, InjectionMoldDto moldDto)
        {
            var mold = await _moldRepository.GetById(moldId);

            mold!.Name = moldDto.Name;
            mold.Producer = moldDto.Producer;
            mold.Size = moldDto.Size;
            mold.Consumption = mold.Consumption;

            if(moldDto.MaterialId != null)
            {
                mold.MaterialId = moldDto.MaterialId;
                mold.Material = await _materialRepository.GetById((int)moldDto.MaterialId!);
            }
            
            await _moldRepository.Commit();
        }

        public async Task Remove(Guid moldId)
        {
            await _moldRepository.Remove(moldId);
        }
    }
}
