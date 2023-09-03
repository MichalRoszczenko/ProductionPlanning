using AutoMapper;
using Production.Application.InjectionMolds;
using Production.Application.InventoryHandling;
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
		private readonly IMaterialInventoryHandler _materialHandler;

		public InjectionMoldService(IInjectionMoldRepository moldRepository, IMapper mapper,
            IMaterialRepository materialRepository, IMaterialInventoryHandler materialHandler)
        {
            _moldRepository = moldRepository;
            _mapper = mapper;
            _materialRepository = materialRepository;
            _materialHandler = materialHandler;
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

            if (moldDto.MaterialId != null)
            {
                if (mold.MaterialId != null)
                {
                    await VipeStockInfo((int)mold.MaterialId);
				}

                mold.MaterialId = moldDto.MaterialId;
                mold.Material = await _materialRepository.GetById((int)moldDto.MaterialId!);
                mold.Material.IsAssigned = true;
			}
            
            await _moldRepository.Commit();

			await _materialHandler.CalculateDemands(mold.Material!);
		}

        public async Task Remove(Guid moldId)
        {
            var mold = await _moldRepository.GetById(moldId);

			if (mold!.MaterialId != null)
			{
				await VipeStockInfo((int)mold.MaterialId);
			}

			await _moldRepository.Remove(moldId);
        }

        private async Task VipeStockInfo(int materialId)
        {
			var material = await _materialRepository.GetById(materialId);
			material.Stock.PlannedMaterialDemand = 0;
			material.Stock.CountMaterialToOrder();
			material.IsAssigned = false;
		}
    }
}
