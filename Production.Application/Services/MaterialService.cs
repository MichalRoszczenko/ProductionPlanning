﻿using AutoMapper;
using Production.Application.Material;
using Production.Domain.Interfaces;

namespace Production.Application.Services
{
    public interface IMaterialService
    {
        Task<IEnumerable<MaterialDto>> GetAll();
        Task<MaterialDto> GetById(int materialId);
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

        public async Task<MaterialDto> GetById(int materialId)
        {
            var material = await _repository.GetById(materialId);
            var materialDto = _mapper.Map<MaterialDto>(material);

            return materialDto;
        }
    }
}