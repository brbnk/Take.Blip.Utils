using Take.Blip.Utils.Models.Dtos;

namespace Take.Blip.Utils.Models.Validators.Interfaces;

public interface IValidationResponse
{
  public BaseValidationResponse ProcessValidation();
}