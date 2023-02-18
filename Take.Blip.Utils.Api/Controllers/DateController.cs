using Microsoft.AspNetCore.Mvc;
using Take.Blip.Utils.Facade.Date.Interfaces;

namespace Take.Blip.Utils.Api;

[Route("api/[controller]")]
public class DateController : ControllerBase
{
  private const double DEFAULT_OFFSET_DATETIME = -3;
  private const string DEFAULT_DATE_FORMAT = "dd/MM/yyyy HH:mm:ss";

  private readonly IDateHandlerFacade _dateHandlerFacade;

  public DateController(IDateHandlerFacade dateHandlerFacade)
  {
    _dateHandlerFacade = dateHandlerFacade;
  }

  /// <summary>
  /// Get the current date
  /// </summary>
  /// <param name="offSetDateTime"> GMT offset </param>
  /// <returns> Current datetime </returns>
  [HttpGet("now")]
  public IActionResult GetCurrentDate(
    [FromQuery] double offSetDateTime = DEFAULT_OFFSET_DATETIME)
  {
    var date = _dateHandlerFacade
        .GetCurrentDate(offSetDateTime);

    return Ok(date);
  }

  /// <summary>
  /// Get the interval days between a given and current date.
  /// </summary>
  /// <param name="previousDate"> Date to compare with current date </param>
  /// <param name="offSetDateTime"> GMT offset </param>
  /// <returns> Interval days </returns>
  [HttpGet("interval")]
  public IActionResult GetIntervalBetweenCurrentAndPreviousDate(
    [FromQuery] string previousDate,
    [FromQuery] double offSetDateTime = DEFAULT_OFFSET_DATETIME)
  {
    var interval = _dateHandlerFacade
      .GetIntervalBetweenCurrentAndPreviousDate(previousDate, offSetDateTime);  

    return Ok(interval);
  }
  
  /// <summary>
  /// Get a formatted date string.
  /// </summary>
  /// <param name="date"> Date to be formatted </param>
  /// <param name="format"> Date format </param>
  /// <returns> Formatted date </returns>
  [HttpGet("format")]
  public IActionResult GetFormattedDate(
    [FromQuery] string date,
    [FromQuery] string format = DEFAULT_DATE_FORMAT)
  {
    var formattedDate = _dateHandlerFacade
      .GetFormattedDate(date, format);

    return Ok(formattedDate);
  }
} 