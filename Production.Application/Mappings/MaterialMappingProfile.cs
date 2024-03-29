﻿using AutoMapper;
using Production.Application.Dtos;
using Production.Domain.Entities;

namespace Production.Application.Mappings
{
    public class MaterialMappingProfile : Profile
    {
        public MaterialMappingProfile()
        {
            CreateMap<Material, MaterialDto>()
                .ForMember(dto => dto.MaterialInStock, opt => opt.MapFrom(src => src.Stock.MaterialInStock))
                .ForMember(dto => dto.PlannedMaterialDemand, opt => opt.MapFrom(src => src.Stock.PlannedMaterialDemand))
                .ForMember(dto => dto.MaterialOnProduction, opt => opt.MapFrom(src => src.Stock.MaterialOnProduction))
                .ForMember(dto => dto.MaterialToOrder, opt => opt.MapFrom(src => src.Stock.MaterialToOrder));

            CreateMap<MaterialDto, Material>().ForMember(m => m.Stock, opt => opt.MapFrom(dto => new MaterialStock()
            {
                MaterialInStock = dto.MaterialInStock,
                PlannedMaterialDemand = dto.PlannedMaterialDemand,
                MaterialOnProduction = dto.MaterialOnProduction
            }));
        }
    }
}
