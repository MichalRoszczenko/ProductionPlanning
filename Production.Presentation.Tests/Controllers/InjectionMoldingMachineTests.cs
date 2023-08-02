using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Moq;
using Production.Application.InjectionMoldMachines;
using Production.Application.Services;
using System.Net;
using Xunit;

namespace Production.Presentation.Controllers.Tests
{
	public class InjectionMoldingMachineTests : IClassFixture<WebApplicationFactory<Program>>
	{
		private readonly WebApplicationFactory<Program> _factory;

		public InjectionMoldingMachineTests(WebApplicationFactory<Program> factory)
        {
			_factory = factory;
		}

        [Fact()]
		public async Task Index_ReturnsViewWithExpectedData_ForExistingInjectionMachines()
		{
			//arrange

			var machinesDto = new List<InjectionMoldingMachineDto>()
			{
				new InjectionMoldingMachineDto()
				{
					Name = "TestMachine1",
					Online = false,
					Size = "TestSize1",
					Tonnage = 3001
				},				
				new InjectionMoldingMachineDto()
				{
					Name = "TestMachine2",
					Online = true,
					Size = "TestSize2",
					Tonnage = 3002
				},				
				new InjectionMoldingMachineDto()
				{
					Name = "TestMachine3",
					Online = true,
					Size = "TestSize3",
					Tonnage = 3003
				},
            };

            var client = CreateClientWithInjectionMachineServiceMock(machinesDto);

            //act 

            var response = await client.GetAsync("/InjectionMoldingMachine");

			//assert

			response.StatusCode.Should().Be(HttpStatusCode.OK);

			var content = await response.Content.ReadAsStringAsync();

			foreach(var machine in machinesDto)
			{
				content.Should().Contain(machine.Name)
					.And.Contain(machine.Size)
					.And.Contain(machine.Tonnage.ToString())
					.And.Contain(machine.Online ? "<input checked=\"checked\" class=\"check-box\"" : "<input class=\"check-box\"");
			}
		}

		[Fact()]
		public async Task Index_ReturnsEmptyView_ForNoExistingInjectionMachines()
		{
			//arrange

			var machinesDto = new List<InjectionMoldingMachineDto>();

            var client = CreateClientWithInjectionMachineServiceMock(machinesDto);

            //act 

            var response = await client.GetAsync("/InjectionMoldingMachine/Index");

			//assert

			response.StatusCode.Should().Be(HttpStatusCode.OK);

			var content = await response.Content.ReadAsStringAsync();


			content.Should().NotContain("Edit\">Edit</a> |")
				.And.NotContain("Details\">Details</a> |")
				.And.NotContain(">Remove</a>");
		}

		[Fact()]
		public async Task Details_ReturnInjectionMachineDetailsView_ForExistingInjectionMachine()
		{
			//arrange

			var machineDto = new InjectionMoldingMachineDto()
			{
				Name = "TestMachine1",
				Online = true,
				Size = "TestSize1",
				Tonnage = 3001
			};

            var machineServiceMock = new Mock<IInjectionMoldingMachineService>();

			machineServiceMock.Setup(s => s.GetById(It.IsAny<int>(),It.IsAny<bool>()))
				.ReturnsAsync(machineDto);

			var client = _factory.WithWebHostBuilder(builder 
				=> builder.ConfigureServices(cfg => cfg.AddScoped(_ => machineServiceMock.Object)))
				.CreateClient();

			//act

			var response = await client.GetAsync("/InjectionMoldingMachine/1/Details");

			//assert

			response.StatusCode.Should().Be(HttpStatusCode.OK);

			var content = await response.Content.ReadAsStringAsync();

			content.Should().Contain($"<dd class = \"col-sm-10\">\r\n            {machineDto.Name}\r\n        </dd>")
				.And.Contain($"<dd class = \"col-sm-10\">\r\n            {machineDto.Size}\r\n        </dd>")
				.And.Contain($"<dd class = \"col-sm-10\">\r\n            {machineDto.Tonnage}\r\n        </dd>")
				.And.Contain(machineDto.Online ? "<input checked=\"checked\" class=\"check-box\"" : "<input class=\"check-box\"");
        }

        private HttpClient CreateClientWithInjectionMachineServiceMock(List<InjectionMoldingMachineDto> machinesDto)
		{
            var machineServiceMock = new Mock<IInjectionMoldingMachineService>();

            machineServiceMock.Setup(e => e.GetAll())
                .ReturnsAsync(machinesDto);

            var client = _factory
                .WithWebHostBuilder(builder
                => builder.ConfigureTestServices(services => services.AddScoped(_ => machineServiceMock.Object)))
                .CreateClient();

			return client;
        }
    }
}