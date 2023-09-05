using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Production.Application.Dtos;
using Production.Domain.Entities;
using Production.Presentation.Tests.Extensions;
using System.Net;
using Xunit;

namespace Production.Presentation.Tests.Controllers.InjectionMoldControllerTests
{
	public class MoldEditActionTests : IClassFixture<WebApplicationFactory<Program>>
	{
		private readonly WebApplicationFactory<Program> _factory;

		public MoldEditActionTests(WebApplicationFactory<Program> factory)
        {
			_factory = factory.CreateInMemoryDatabase();
		}

        [Fact()]
		public async Task Edit_ReturnInjectionMoldEditView_ForExistingInjectionMold()
		{
			//arrange

			var injectionMold = new InjectionMold()
			{
				Name = "TestMold",
				Size = "TestSize",
				Producer = "TestProducer",
				Consumption = 5.55M,
				Productions = new List<Domain.Entities.Production>()

			};

			var injectionMoldDto = new InjectionMoldDto()
			{
				Name = "TestMold",
				Size = "TestSize",
				Consumption = 5.55M,
				Producer = "TestProducer",
			};

			var materials = new List<Material>()
			{
				new Material()
				{
					Name = "testMat1",
					Description = "TestDesc1",
					Type = "TestType1"
				},
				new Material()
				{
					Name = "testMat2",
					Description = "TestDesc2",
					Type = "TestType2"
				},
				new Material()
				{
					Name = "testMat3",
					Description = "TestDesc3",
					Type = "TestType3"
				}
			};

			await _factory.AddElementToDb(injectionMold);
			await _factory.AddElementsToDb(materials);

			var client = _factory.CreateClient();

			//act

			var response = await client.GetAsync($"/InjectionMold/{injectionMold.Id}/Edit");

			//assert

			response.StatusCode.Should().Be(HttpStatusCode.OK);

			var content = await response.Content.ReadAsStringAsync();

			content.Should().Contain($"id=\"Name\" name=\"Name\" value=\"{injectionMoldDto.Name}\"")
				.And.Contain($"id=\"Producer\" name=\"Producer\" value=\"{injectionMoldDto.Producer}\"")
				.And.Contain($" id=\"Size\" name=\"Size\" value=\"{injectionMoldDto.Size}\"")
				.And.Contain($"id=\"Consumption\" name=\"Consumption\" value=\"{injectionMoldDto.Consumption
					.ToString().Replace(",", ".")}\"");

			for( int i = 0; i < materials.Count; i++ )
			{
				content.Should().Contain($"{materials[i].Name}");
			}
		}
	}
}
