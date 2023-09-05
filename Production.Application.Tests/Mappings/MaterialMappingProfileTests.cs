using AutoMapper;
using FluentAssertions;
using Production.Application.Dtos;
using Production.Application.Mappings;
using Xunit;
namespace Production.Application.Tests.Mappings
{
	public class MaterialMappingProfileTests
	{
		private readonly IMapper _mapper;

		public MaterialMappingProfileTests()
		{
			var configuration = new MapperConfiguration(cfg
				=> cfg.AddProfile(new MaterialMappingProfile()));

			_mapper = configuration.CreateMapper();
		}

		[Fact()]
		public void MappingProfile_ShouldMapMaterialToMaterialDto()
		{
			//arrange

			var material = new Domain.Entities.Material()
			{
				Stock = new Domain.Entities.MaterialStock()
				{
					MaterialInStock = 500,
					MaterialOnProduction = 155,
					PlannedMaterialDemand = 1000
				}
			};

			material.Stock.CountMaterialToOrder();

			var materialDto = new MaterialDto()
			{
				MaterialInStock = 500,
				MaterialOnProduction = 155,
				PlannedMaterialDemand = 1000,
				MaterialToOrder = 500
			};

			//act

			var result = _mapper.Map<MaterialDto>(material);

			//assert

			result.Should().BeEquivalentTo(materialDto);
		}

		[Fact()]
		public void MappingProfile_ShouldMapMaterialDtoToMaterial()
		{
			//arrange

			var material = new Domain.Entities.Material()
			{
				Stock = new Domain.Entities.MaterialStock()
				{
					MaterialInStock = 500,
					MaterialOnProduction = 155,
					PlannedMaterialDemand = 1000
				}
			};

			material.Stock.CountMaterialToOrder();

			var materialDto = new MaterialDto()
			{
				MaterialInStock = 500,
				MaterialOnProduction = 155,
				PlannedMaterialDemand = 1000,
			};

			//act

			var result = _mapper.Map<Domain.Entities.Material>(materialDto);
			result.Stock.CountMaterialToOrder();

			//assert

			result.Should().BeEquivalentTo(material);
		}
	}
}