﻿using AutoMapper;
using Production.Application.Dtos;
using Production.Application.Interfaces;
using Production.Domain.Entities;
using Production.Domain.Interfaces;

namespace Production.Application.Services
{
    internal sealed class InjectionMoldService : IDatabaseCrudService<InjectionMoldDto,Guid>
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

		public async Task<InjectionMoldDto> GetById(Guid itemId)
		{
			var mold = await _moldRepository.GetById(itemId, true);
			var dto = _mapper.Map<InjectionMoldDto>(mold);

			return dto;
		}

		public async Task Create(InjectionMoldDto itemDto)
		{
			var mold = _mapper.Map<InjectionMold>(itemDto);
			await _moldRepository.Create(mold);
		}

		public async Task Update(Guid itemId, InjectionMoldDto itemDto)
		{
			var mold = await _moldRepository.GetById(itemId);

			UpdateMoldProperties(mold!, itemDto);

			await UpdateMaterialInfo(mold, itemDto);
		}
		
		private void UpdateMoldProperties(InjectionMold mold, InjectionMoldDto moldDto)
		{
			mold!.Name = moldDto.Name;
			mold.Producer = moldDto.Producer;
			mold.Size = moldDto.Size;
			mold.Consumption = moldDto.Consumption;
		}

		private async Task UpdateMaterialInfo(InjectionMold mold, InjectionMoldDto moldDto)
		{
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

			if (moldDto.MaterialId != null || mold.Consumption == moldDto.Consumption)
			{
				await _materialHandler.CalculateDemands(mold.Material!);
			}
		}

		public async Task Remove(Guid itemId)
		{
			var mold = await _moldRepository.GetById(itemId);

			if (mold!.MaterialId != null)
			{
				await VipeStockInfo((int)mold.MaterialId);
			}

			await _moldRepository.Remove(itemId);
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
