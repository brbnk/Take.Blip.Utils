using Microsoft.AspNetCore.Mvc;
using Take.Blip.Utils.Facade.Interfaces;
using Take.Blip.Utils.Models.Validators;

namespace Take.Blip.Utils.Api.Controllers;

[Route("api/[controller]")]
public sealed class DataValidatorController : ControllerBase
{
  private readonly IDataValidatorFacade _dataValidatorFacade;

  public DataValidatorController(IDataValidatorFacade DataValidatorFacade)
  {
    _dataValidatorFacade = DataValidatorFacade;
  }

  [HttpGet("cpf")]
  public IActionResult ValidateCpf([FromHeader] string cpf)
  {
    var data = _dataValidatorFacade
      .Validate(typeof(CPFValidator), cpf);

    return Ok(data);
  }

  [HttpGet("birthDate")]
  public IActionResult ValidateBirthDate([FromHeader] string birthDate)
  {
    var data = _dataValidatorFacade
      .Validate(typeof(BirthDateValidator), birthDate);

    return Ok(data);
  }

  [HttpGet("money")]
  public IActionResult ValidateMoney([FromQuery] string money)
  {
    var data = _dataValidatorFacade
      .Validate(typeof(MoneyValidator), money);

    return Ok(data);
  }

  [HttpGet("yesOrNo")]
  public IActionResult ValidateYesOrNo([FromQuery] string input)
  {
    var data = _dataValidatorFacade
      .Validate(typeof(YesOrNoValidation), input);

    return Ok(data);
  }
}