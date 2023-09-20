﻿using AutoMapper;
using Production.Application.Dtos;
using Production.Application.Interfaces;
using Production.Domain.Interfaces;

namespace Production.Application.Services
{
    public class MaterialService : IDatabaseService<MaterialDto, int>
	{
		private readonly IMaterialRepository _repository;
		private readonly IMapper _mapper;
		private readonly IMaterialInventoryHandler _materialHandler;

		public MaterialService(IMaterialRepository repository, IMapper mapper,
			IMaterialInventoryHandler materialHandler)
		{
			_repository = repository;
			_mapper = mapper;
			_materialHandler = materialHandler;
		}
		public async Task<IEnumerable<MaterialDto>> GetAll()
		{
			var materials = await _repository.GetAll();
			var materialsDto = _mapper.Map<IEnumerable<MaterialDto>>(materials);
			return materialsDto;
		}

		public async Task<MaterialDto> GetById(int materialId)
		{
			var material = await _repository.GetById(materialId);
			var materialDto = _mapper.Map<MaterialDto>(material);

			return materialDto;
		}

		public async Task Create(MaterialDto materialDto)
		{
			var material = _mapper.Map<Domain.Entities.Material>(materialDto);
			await _repository.Create(material);
		}

		public async Task Update(int materialId, MaterialDto materialDto)
		{
			var material = await _repository.GetById(materialId);

			material.Name = materialDto.Name;
			material.Type = materialDto.Type;
			material.Cost = materialDto.Cost;
			material.Description = materialDto.Description;
			material.Stock.MaterialInStock = materialDto.MaterialInStock;

			await _materialHandler.CalculateDemands(material);

			await _repository.Commit();
		}

		public async Task Remove(int materialId)
		{
			var material = await _repository.GetById(materialId);

			await _materialHandler.RemoveMaterialFromProductions(material);

			await _repository.Remove(material);
		}
	}
}
