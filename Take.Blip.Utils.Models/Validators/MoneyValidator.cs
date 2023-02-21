using System.Globalization;
using Take.Blip.Utils.Models.Base;
using Take.Blip.Utils.Models.Dtos;
using Take.Blip.Utils.Models.Dtos.Input;

namespace Take.Blip.Utils.Models.Validators;

public sealed class MoneyValidator : DataValidator
{

  private const string ERROR_IDENTIFIER = "moneyValidationError";
  private decimal _moneyInput;

  public MoneyValidator(string input) : base(input)
  {
  }

  protected override string Cleaner(string input) 
  {
    var money = input.Trim();

    var decimalCommaIndex = money.LastIndexOf(",");

    if (decimalCommaIndex >= 0)
    {
      var intPart = NormalizeIntPart(money.Substring(0, decimalCommaIndex));
      var decimalPart = money.Substring(decimalCommaIndex + 1);

      money = $"{intPart}.{decimalPart}";
    }

    return NormalizeMoney(money);
  } 

  protected override string Formatter(string cleanedInput) =>
    string.Format(
      CultureInfo.GetCultureInfo(Constants.DEFAULT_CULTURE_INFO_NAME), 
      Constants.DEFAULT_MONEY_FORMAT, 
      _moneyInput);

  protected override bool Validator(string cleanedInput) 
  {
    var formatProvider = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
    var culture = CultureInfo.GetCultureInfo(Constants.DEFAULT_CULTURE_INFO_NAME);

    return decimal.TryParse(cleanedInput, formatProvider, culture, out _moneyInput);
  }

  protected override string Responser(string cleanedInput) => cleanedInput.Replace(",", ".");

  protected override string SetErrorIdentifer() => ERROR_IDENTIFIER;

  public override BaseValidationResponse ProcessValidation()
  {
    var baseResponse = (ValidationResponse) base.ProcessValidation();

    var data = baseResponse.Data;

    var moneyResponse = new MoneyValidationResponse(data)
    {
      Truncated = data.IsValid ? 
        GetTruncatedMoney(_moneyInput) : Constants.UNEXPECTED_INPUT
    };

    return new ValidationResponse<MoneyValidationResponse>(moneyResponse);
  }

  #region Private methods
  private string NormalizeIntPart(string money) =>
    money.Replace(",", "").Replace(".", "");

  private string NormalizeMoney(string money) =>
    money.Replace(",", "").Replace(".", ",");

  private string GetTruncatedMoney(decimal money) =>
    Math.Truncate(money).ToString();
  #endregion
}