using System.Text.RegularExpressions;
using Take.Blip.Utils.Models.Base;

namespace Take.Blip.Utils.Models.Validators;

public sealed class BirthDateValidator : DataValidator
{
  private const string BIRTH_DATE_REGEX_PATTERN = @"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[13-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$";
  private const string SEPARATOR = "/";

  public BirthDateValidator(string input) : base(input)
  {
  }

  protected override string Cleaner(string input) => input.Trim();

  protected override string Formatter(string cleanedInput) =>
    Regex.Replace(cleanedInput, @"\D+", SEPARATOR);

  protected override bool Validator(string cleanedInput) =>
    Regex.IsMatch(cleanedInput, BIRTH_DATE_REGEX_PATTERN, RegexOptions.IgnoreCase | RegexOptions.Multiline);
}