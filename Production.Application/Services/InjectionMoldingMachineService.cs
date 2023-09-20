using AutoMapper;
using Production.Application.Dtos;
using Production.Application.Interfaces;
using Production.Domain.Entities;
using Production.Domain.Interfaces;

namespace Production.Application.Services
{
    internal sealed class InjectionMoldingMachineService : IDatabaseService<InjectionMoldingMachineDto,int>
	{
		private readonly IInjectionMoldingMachineRepository _machineRepository;
		private readonly IMapper _mapper;

		public InjectionMoldingMachineService(IInjectionMoldingMachineRepository machineRepository, IMapper mapper)
		{
			_machineRepository = machineRepository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<InjectionMoldingMachineDto>> GetAll()
		{
			var machines = await _machineRepository.GetAll();

			var itemDto = _mapper.Map<IEnumerable<InjectionMoldingMachineDto>>(machines);

			return itemDto;
		}

		public async Task<InjectionMoldingMachineDto> GetById(int itemId, bool withProductionInfo = false)
		{
			var machine = await _machineRepository.GetById(itemId, withProductionInfo);

			var itemDto = _mapper.Map<InjectionMoldingMachineDto>(machine);

			return itemDto;
		}

		public async Task Update(int itemId, InjectionMoldingMachineDto itemDto)
		{
			var machine = await _machineRepository.GetById(itemId);

			machine!.Name = itemDto.Name;
			machine.Size = itemDto.Size;
			machine.Tonnage = itemDto.Tonnage;
			machine.Online = itemDto.Online;

			await _machineRepository.Commit();
		}

		public async Task Create(InjectionMoldingMachineDto itemDto)
		{
			var machine = _mapper.Map<InjectionMoldingMachine>(itemDto);
			await _machineRepository.Create(machine);
		}

		public async Task Remove(int itemId)
		{
			await _machineRepository.Remove(itemId);
		}
	}
}
