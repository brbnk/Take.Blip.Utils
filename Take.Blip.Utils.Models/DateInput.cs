using Take.Blip.Utils.Models.Base;

namespace Take.Blip.Utils.Models;

public sealed class DateInput : DataValidation
{
  private const string DATE_FORMAT = "dd/MM/yyyy HH:mm:ss";

  public DateInput(string input)
  {
    SetUserInput(input);
  }

  protected override string FormatData()
  {
    var isValidInput = ValidateData();

    if (isValidInput)
    {
      var date = DateTime.Parse(BlipUserInput);

      return date.ToString(DATE_FORMAT);
    }
    
    return "input inesperado";
  }

  protected override bool ValidateData()
  {
    return DateTime.TryParse(BlipUserInput, out _);
  }
}