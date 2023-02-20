using Take.Blip.Utils.Models.Base;

namespace Take.Blip.Utils.Models;

public sealed class DateInput : DataValidator
{
  private const string FULL_DATETIME_FORMAT = "dd/MM/yyyy HH:mm:ss";
  private const string DATE_FORMAT = "dd/MM/yyyy";

  private DateTimeOffset _dateTimeOffset;

  public DateInput(string input) : base(input) 
  { 
  }

  protected override string Cleaner(string input) => input.Trim();

  protected override string Formatter(string input) =>
    _dateTimeOffset.ToString(FULL_DATETIME_FORMAT);

  protected override bool Validator(string input) =>
    DateTimeOffset.TryParse(input, out _dateTimeOffset);
}