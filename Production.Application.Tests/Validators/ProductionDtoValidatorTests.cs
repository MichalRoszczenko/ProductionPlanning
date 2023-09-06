using FluentValidation.TestHelper;
using Moq;
using Production.Application.Dtos;
using Production.Application.Tests.TestsData.ValidatorsTestData;
using Production.Application.Validators;
using Production.Domain.Entities;
using Production.Domain.Interfaces;
using Xunit;

namespace Production.Application.Tests.Validators
{
    public class ProductionDtoValidatorTests
    {       
        [Theory()]
        [ClassData(typeof(CorrectProductionDtoValidatorTestData))]
        public void ProductionDto_ShouldNotHaveValidationErrors_ForValidData(InjectionMold mold,
            InjectionMoldingMachine machine, ProductionDto productionDto)
        {
            //arrange

            var validator = CreateValidatorWithMockedMoldAndMachine(mold, machine);

            //act

            var result = validator.TestValidate(productionDto);

            //assert

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Theory()]
        [ClassData(typeof(IncorrectProductionDtoValidatorTestData))]
        public void ProductionValidator_ShouldHaveValidationErrors_ForNoValidData(InjectionMold mold,
            InjectionMoldingMachine machine, ProductionDto productionDto)
        {
            //arrange

            var validator = CreateValidatorWithMockedMoldAndMachine(mold, machine);

            //act

            var result = validator.TestValidate(productionDto);

            //assert

            result.ShouldHaveValidationErrorFor(m => m.End);
            result.ShouldHaveValidationErrorFor(m => m.InjectionMoldingMachineId);
            result.ShouldHaveValidationErrorFor(m => m.InjectionMoldId);
        }

        [Fact()]
        public void ProductionValidator_StartShouldHaveValidationError_ForNullValue()
        {
            //arrange

            var mold = new InjectionMold();
            var machine = new InjectionMoldingMachine();
            var productionDto = new ProductionDto()
            {
                End = new DateTime(2002, 2, 2, 15, 30, 00),
            };

            var validator = CreateValidatorWithMockedMoldAndMachine(mold, machine);

            //act

            var validationResult = validator.TestValidate(productionDto);

            //assert

            validationResult.ShouldHaveValidationErrorFor(m => m.Start);
        }

        private ProductionDtoValidator CreateValidatorWithMockedMoldAndMachine(InjectionMold mold,
            InjectionMoldingMachine machine)
        {
            var moldRepositoryMock = new Mock<IInjectionMoldRepository>();
            moldRepositoryMock.Setup(a => a.GetById(mold.Id, It.IsAny<bool>()))
                .ReturnsAsync(mold);

            var machineRepositoryMock = new Mock<IInjectionMoldingMachineRepository>();
            machineRepositoryMock.Setup(s
                => s.GetById(machine.Id, It.IsAny<bool>()))
                .ReturnsAsync(machine);

            var validator = new ProductionDtoValidator(moldRepositoryMock.Object, machineRepositoryMock.Object);

            return validator;
        }
    }
}