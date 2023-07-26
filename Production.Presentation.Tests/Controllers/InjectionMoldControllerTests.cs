﻿using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Moq;
using Production.Application.InjectionMolds;
using Production.Application.Services;
using System.Net;
using Xunit;

namespace Production.Presentation.Controllers.Tests
{
	public class InjectionMoldControllerTests : IClassFixture<WebApplicationFactory<Program>>
	{
		private readonly WebApplicationFactory<Program> _factory;

		public InjectionMoldControllerTests(WebApplicationFactory<Program> factory)
        {
			_factory = factory;
		}

        [Fact()]
		public async Task Index_ReturnsViewWithExpectedData_ForExistingInjectionMolds()
		{
			//arrange

			var moldsDto = new List<InjectionMoldDto>()
			{
				new InjectionMoldDto()
				{
					Name = "TestMold1",
					Size = "TestSize1",
					Producer = "TestProducer1"
				},
				new InjectionMoldDto()
				{
					Name = "TestMold2",
					Size = "TestSize2",
					Producer = "TestProducer2"
				},
				new InjectionMoldDto()
				{
					Name = "TestMold3",
					Size = "TestSize3",
					Producer = "TestProducer3"
				},
			};

            var client = CreateClientWithInjectionMoldServiceMock(moldsDto);

            //act 

            var response = await client.GetAsync("/InjectionMold/Index");

			//assert

			response.StatusCode.Should().Be(HttpStatusCode.OK);

			var content = await response.Content.ReadAsStringAsync();

			foreach(var mold in moldsDto)
			{
				content.Should().Contain(mold.Name)
					.And.Contain(mold.Size)
					.And.Contain(mold.Producer);
			}
		}

        [Fact()]
        public async Task Index_ReturnsEmptyView_ForNoExistingInjectionMolds()
        {
			//arrange

			var moldsDto = new List<InjectionMoldDto>();


            var client = CreateClientWithInjectionMoldServiceMock(moldsDto);

            //act 

            var response = await client.GetAsync("/InjectionMold/Index");

            //assert

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();

            content.Should().NotContain("Edit\">Edit</a> |")
                .And.NotContain("Details\">Details</a> |")
                .And.NotContain(">Remove</a>");
        }

        [Fact()]
		public async Task Details_ReturnInjectionMoldDetailsView_ForExistingInjectionMold()
		{
			//arrange

			var injectionMoldDto = new InjectionMoldDto()
			{
				Name = "TestMold",
				Size = "TestSize",
				Producer = "TestProducer"
			};

            var injectionServiceMock = new Mock<IInjectionMoldService>();

            injectionServiceMock.Setup(s => s.GetById(It.IsAny<Guid>()))
				.ReturnsAsync(injectionMoldDto);

			var client = _factory.WithWebHostBuilder(builder 
				=> builder.ConfigureServices(cfg => cfg.AddScoped(_ => injectionServiceMock.Object)))
				.CreateClient();

			//act

			var response = await client.GetAsync("/InjectionMold/1/Details");

			//assert

			response.StatusCode.Should().Be(HttpStatusCode.OK);

			var content = await response.Content.ReadAsStringAsync();

			content.Should().Contain($"<dd class = \"col-sm-10\">\r\n            {injectionMoldDto.Name}\r\n        </dd>")
				.And.Contain($"<dd class = \"col-sm-10\">\r\n            {injectionMoldDto.Size}\r\n        </dd>")
				.And.Contain($"<dd class = \"col-sm-10\">\r\n            {injectionMoldDto.Producer}\r\n        </dd>");
        }

        private HttpClient CreateClientWithInjectionMoldServiceMock(List<InjectionMoldDto> moldsDto)
		{
            var injectionServiceMock = new Mock<IInjectionMoldService>();

            injectionServiceMock.Setup(e => e.GetAll())
                .ReturnsAsync(moldsDto);

            var client = _factory
                .WithWebHostBuilder(builder
                => builder.ConfigureTestServices(services => services.AddScoped(_ => injectionServiceMock.Object)))
                .CreateClient();

			return client;
        }
    }
}