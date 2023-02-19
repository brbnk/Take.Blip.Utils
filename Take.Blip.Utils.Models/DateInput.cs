using Take.Blip.Utils.Models.Base;

namespace Take.Blip.Utils.Models;

public sealed class DateInput : DataValidation
{
  private const string FULL_DATETIME_FORMAT = "dd/MM/yyyy HH:mm:ss";
  private const string DATE_FORMAT = "dd/MM/yyyy";

  private DateTimeOffset _dateTimeOffset;

  public DateInput(string input) : base(input) 
  { 
  }

  protected override string FormatData(string input)
  {
    return !IsValid ? UNEXPECTED_INPUT : _dateTimeOffset.ToString(FULL_DATETIME_FORMAT);
  }

  protected override string GetValue(string input)
  {
    return !IsValid ? UNEXPECTED_INPUT : _dateTimeOffset.ToString(DATE_FORMAT);
  }

  protected override bool ValidateData(string input)
  {
    return DateTimeOffset.TryParse(input, out _dateTimeOffset);
  }
}