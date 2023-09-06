using FluentValidation.TestHelper;
using Production.Application.Dtos;
using Production.Application.Tests.TestsData.ValidatorsTestData;
using Xunit;

namespace Production.Application.Validators.Tests
{
    public class InjectionMoldDtoValidatorTests
    {
        [Theory()]
        [ClassData(typeof(CorrectInjectionMoldDtoValidatorTestData))]
        public void InjectionMoldDto_ShouldNotHaveAnyValidationErrors_ForCorrectData(InjectionMoldDto injectionMoldDto)
        {
            //arrange

            var validator = new InjectionMoldDtoValidator();

            //act

            var validationResult = validator.TestValidate(injectionMoldDto);

            //assert

            validationResult.ShouldNotHaveAnyValidationErrors();
        }        
        
        [Theory()]
        [ClassData(typeof(IncorrectInjectionMoldDtoValidatorTestData))]
        public void InjectionMoldDto_ShouldHaveValidationErrors_ForIncorrectData(InjectionMoldDto injectionMoldDto)
        {
            //arrange

            var validator = new InjectionMoldDtoValidator();

            //act

            var validationResult = validator.TestValidate(injectionMoldDto);

            //assert

            validationResult.ShouldHaveValidationErrorFor(x => x.Name);
            validationResult.ShouldHaveValidationErrorFor(x => x.Size);
            validationResult.ShouldHaveValidationErrorFor(x => x.Producer);
            validationResult.ShouldHaveValidationErrorFor(x => x.Consumption);
        }
    }
}