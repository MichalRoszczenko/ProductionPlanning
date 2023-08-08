﻿using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using Production.Application.Productions;
using Production.Application.Services;
using System.Net;
using Xunit;

namespace Production.Presentation.Tests.Controllers.ProductionControllerTests
{
    public class ProductionDetailsActionTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public ProductionDetailsActionTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact()]
        public async Task Details_ReturnProductionDetailsView_ForExistingProduction()
        {
            //arrange

            var productionDto = new ProductionDto()
            {
                Start = new DateTime(2023, 08, 15, 15, 20, 00),
                End = new DateTime(2023, 08, 15, 15, 20, 00),
                InjectionMoldingMachineName = "TestMachine1",
                InjectionMoldName = "TestMold1"
            };

            var client = CreateClientWithProductionServiceMock(productionDto);

            //act

            var response = await client.GetAsync("/Production/1/Details");

            //assert

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();

            content.Should().Contain($"<dd class = \"col-sm-10\">\r\n            {productionDto.Start}\r\n        </dd>")
                .And.Contain($"<dd class = \"col-sm-10\">\r\n            {productionDto.Start}\r\n        </dd>")
                .And.Contain($"<dd class = \"col-sm-10\">\r\n            {productionDto.InjectionMoldingMachineName}\r\n        </dd>")
                .And.Contain($"<dd class = \"col-sm-10\">\r\n            {productionDto.InjectionMoldName}\r\n        </dd>");
        }

        private HttpClient CreateClientWithProductionServiceMock(ProductionDto productionDto)
        {
            var productionSerivceMock = new Mock<IProductionService>();

            productionSerivceMock.Setup(e => e.GetById(It.IsAny<int>()))
                .ReturnsAsync(productionDto);

            var client = _factory.WithWebHostBuilder(builder
                => builder.ConfigureServices(cfg => cfg.AddScoped(_ => productionSerivceMock.Object)))
                .CreateClient();

            return client;
        }
    }
}
