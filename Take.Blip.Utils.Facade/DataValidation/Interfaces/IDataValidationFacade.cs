using Take.Blip.Utils.Models.Base;
using Take.Blip.Utils.Models.Inputs;

namespace Take.Blip.Utils.Facade.Interfaces;

public interface IDataValidationFacade
{
  public Response<CPFValidator> ValidateCpf(string cpf);
}