using Take.Blip.Utils.Facade.Date.Interfaces;

namespace Take.Blip.Utils.Facade.Date;

public sealed class DateHandlerFacade : IDateHandlerFacade
{
  public DateTimeOffset GetCurrentDate(double offSetDateTime)
  {
    var now = DateTimeOffset.UtcNow;

    var currentDate = now.AddHours(offSetDateTime);

    return currentDate;
  }

  public int GetIntervalBetweenCurrentAndPreviousDate(string previousDate, double offSetDateTime)
  {
    if (DateTimeOffset.TryParse(previousDate, out var previous)) 
    {
      var now = GetCurrentDate(offSetDateTime);
      return (now - previous).Days;
    }
    
    throw new InvalidDataException();
  }

  public string GetFormattedDate(string date, string format)
  {
    if (DateTimeOffset.TryParse(date, out var parsedDate))
    { 
      return parsedDate.ToString(format);
    }

    throw new InvalidDataException();
  }
}