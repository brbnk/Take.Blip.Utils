using Take.Blip.Utils.Facade.Interfaces;
using Take.Blip.Utils.Models.Base;
using Take.Blip.Utils.Models.Inputs;

namespace Take.Blip.Utils.Facade.DataValidation;

public sealed class DataValidationFacade : IDataValidationFacade
{
  public Response<CPFValidator> ValidateCpf(string cpf)
  {
    var validatedCpf = new CPFValidator(cpf);

    var response = new Response<CPFValidator> 
    { 
      Data = validatedCpf 
    };

    return response;
  }
}