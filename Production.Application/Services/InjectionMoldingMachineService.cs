using AutoMapper;
using Production.Application.Dtos;
using Production.Application.Interfaces;
using Production.Domain.Entities;
using Production.Domain.Interfaces;
using System.Reflection.PortableExecutable;

namespace Production.Application.Services
{
    internal sealed class InjectionMoldingMachineService : IDatabaseCrudService<InjectionMoldingMachineDto,int>
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

		public async Task<InjectionMoldingMachineDto> GetById(int itemId)
		{
			var machine = await _machineRepository.GetById(itemId, true);

			var itemDto = _mapper.Map<InjectionMoldingMachineDto>(machine);

			return itemDto;
		}

		public async Task Update(int itemId, InjectionMoldingMachineDto itemDto)
		{
			var machine = await _machineRepository.GetById(itemId);

			UpdateMachineProperties(machine!, itemDto);

			await _machineRepository.Commit();
		}

		public void UpdateMachineProperties(InjectionMoldingMachine machine, InjectionMoldingMachineDto machineDto)
		{
			machine!.Name = machineDto.Name;
			machine.Size = machineDto.Size;
			machine.Tonnage = machineDto.Tonnage;
			machine.Online = machineDto.Online;
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
