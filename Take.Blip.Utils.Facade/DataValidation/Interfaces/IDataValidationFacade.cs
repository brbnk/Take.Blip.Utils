using Take.Blip.Utils.Models.Dtos;

namespace Take.Blip.Utils.Facade.Interfaces;

public interface IDataValidatorFacade
{
  public BaseValidationResponse Validate(Type validatorType, string input);
}