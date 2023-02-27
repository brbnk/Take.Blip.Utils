namespace Take.Blip.Utils.Facade.Date.Interfaces;

public interface IDateHandlerFacade
{
  public DateTimeOffset GetCurrentDate(double offSetDateTime);
  public int GetIntervalBetweenCurrentAndPreviousDate(string previousDate, double offSetDateTime);
  public string GetFormattedDate(string date, string format);
}