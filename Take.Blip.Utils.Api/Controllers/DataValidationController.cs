using Microsoft.AspNetCore.Mvc;
using Take.Blip.Utils.Facade.Interfaces;
using Take.Blip.Utils.Models.Validators;

namespace Take.Blip.Utils.Api.Controllers;

[Route("api/[controller]")]
public sealed class DataValidationController : ControllerBase
{
  private readonly IDataValidationFacade _dataValidationFacade;

  public DataValidationController(IDataValidationFacade dataValidationFacade)
  {
    _dataValidationFacade = dataValidationFacade;
  }

  [HttpGet("cpf")]
  public IActionResult ValidateCpf([FromHeader] string cpf)
  {
    var data = _dataValidationFacade
      .Validate(typeof(CPFValidator), cpf);

    return Ok(data);
  }

  [HttpGet("birthDate")]
  public IActionResult ValidateBirthDate([FromHeader] string birthDate)
  {
    var data = _dataValidationFacade
      .Validate(typeof(BirthDateValidator), birthDate);

    return Ok(data);
  }
}