using Microsoft.AspNetCore.Mvc;
using Take.Blip.Utils.Facade.Interfaces;

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
    var data = _dataValidationFacade.ValidateCpf(cpf);

    return Ok(data);
  }
}