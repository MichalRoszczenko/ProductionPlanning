using AutoMapper;
using Production.Application.Dtos;
using Production.Application.Interfaces;
using Production.Domain.Entities;
using Production.Domain.Interfaces;

namespace Production.Application.Services
{
    public class InjectionMoldingMachineService : IInjectionMoldingMachineService
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

			var machineDto = _mapper.Map<IEnumerable<InjectionMoldingMachineDto>>(machines);

			return machineDto;
		}

		public async Task<InjectionMoldingMachineDto> GetById(int machineId, bool withProductionInfo = false)
		{
			var machine = await _machineRepository.GetById(machineId, withProductionInfo);

			var machineDto = _mapper.Map<InjectionMoldingMachineDto>(machine);

			return machineDto;
		}

		public async Task Update(int machineId, InjectionMoldingMachineDto machineDto)
		{
			var machine = await _machineRepository.GetById(machineId);

			machine!.Name = machineDto.Name;
			machine.Size = machineDto.Size;
			machine.Tonnage = machineDto.Tonnage;
			machine.Online = machineDto.Online;

			await _machineRepository.Commit();
		}

		public async Task Create(InjectionMoldingMachineDto machineDto)
		{
			var machine = _mapper.Map<InjectionMoldingMachine>(machineDto);
			await _machineRepository.Create(machine);
		}

		public async Task Remove(int machineId)
		{
			await _machineRepository.Remove(machineId);
		}
	}
}
