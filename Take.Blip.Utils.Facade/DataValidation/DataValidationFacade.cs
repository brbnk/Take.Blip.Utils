using Take.Blip.Utils.Facade.Interfaces;
using Take.Blip.Utils.Models.Dtos;
using Take.Blip.Utils.Models.Validators.Interfaces;

namespace Take.Blip.Utils.Facade.DataValidator;

public sealed class DataValidatorFacade : IDataValidatorFacade
{
  public BaseValidationResponse Validate(Type validatorType, string input)
  {
    var validator = (IValidationResponse) Activator.CreateInstance(validatorType, new object[] { input });

    return validator.ProcessValidation();
  }
}