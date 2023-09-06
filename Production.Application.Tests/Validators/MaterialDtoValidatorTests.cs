using FluentValidation.TestHelper;
using Production.Application.Dtos;
using Production.Application.Tests.TestsData.ValidatorsTestData;
using Xunit;

namespace Production.Application.Validators.Tests
{
	public class MaterialDtoValidatorTests
	{
		[Theory()]
		[ClassData(typeof(CorrectMaterialDtoValidatorTestData))]
		public void MaterialDto_ShouldNotHaveValidationErrors_ForCorrectData(MaterialDto materialDto)
		{
			//arrange

			var validator = new MaterialDtoValidator();

			//act

			var validationResult = validator.TestValidate(materialDto);

			//assert

			validationResult.ShouldNotHaveAnyValidationErrors();
		}

		[Theory()]
		[ClassData(typeof(IncorrectMaterialDtoValidatorTestData))]
		public void MaterialDto_ShouldHaveValidationErrors_ForIncorrectData(MaterialDto materialDto)
		{
			//arrange

			var validator = new MaterialDtoValidator();

			//act

			var validationResult = validator.TestValidate(materialDto);

			//assert

			validationResult.ShouldHaveValidationErrorFor(m => m.Name);
			validationResult.ShouldHaveValidationErrorFor(m => m.Type);
			validationResult.ShouldHaveValidationErrorFor(m => m.Description);
			validationResult.ShouldHaveValidationErrorFor(m => m.MaterialInStock);
		}
	}
}