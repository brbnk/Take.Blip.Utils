using Take.Blip.Utils.Models.Dtos;
using Take.Blip.Utils.Models.Inputs;

namespace Take.Blip.Utils.Facade.Interfaces;

public interface IDataValidationFacade
{
  public ValidationResponse Validate(Type validatorType, string input);
}