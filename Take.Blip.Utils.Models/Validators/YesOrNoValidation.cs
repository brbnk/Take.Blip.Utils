using System.Text.RegularExpressions;
using Take.Blip.Utils.Models.Base;
using Take.Blip.Utils.Models.Dtos;
using Take.Blip.Utils.Models.Dtos.Input;

namespace Take.Blip.Utils.Models.Validators;

public sealed class YesOrNoValidation : DataValidator
{
  private const string ERROR_IDENTIFIER = "yesOrNoValidationError";
  private const string AFFIRMATIVE_PATTERN = @"^(s+|si+m|y|yes|ok|(a|u)h(a|u)(n|m)|ta\s+(bom|bem))$";
  private const string NEGATIVE_PATTERN = @"^(n+|n(a|ã)+o(\s+?(quero|aceito))?|no)$";

  private bool _isAffirmativeAnswer;

  public YesOrNoValidation(string input) : base(input)
  {
  }

  protected override string Cleaner(string input) => input?.Trim();

  protected override string Formatter(string cleanedInput) =>
    _isAffirmativeAnswer ? "Sim" : "Não";

  protected override string Responser(string cleanedInput) =>
    _isAffirmativeAnswer ? "Sim" : "Não";

  protected override bool Validator(string cleanedInput) 
  {
    var isAffirmative = Regex.IsMatch(cleanedInput, AFFIRMATIVE_PATTERN, Constants.DEFAULT_REGEX_OPTIONS);
    var isNegative = Regex.IsMatch(cleanedInput, NEGATIVE_PATTERN, Constants.DEFAULT_REGEX_OPTIONS);

    _isAffirmativeAnswer = isAffirmative;

    return (isAffirmative || isNegative);
  }

  protected override string SetErrorIdentifer() => ERROR_IDENTIFIER;

  public override BaseValidationResponse ProcessValidation()
  {
     var baseResponse = (ValidationResponse) base.ProcessValidation();

     var data = baseResponse.Data;

     var yesOrNoResponse = new YesOrNoValidationResponse(data) 
     {
       Decision = data.IsValid ? _isAffirmativeAnswer : false
     };

     return new ValidationResponse<YesOrNoValidationResponse>(yesOrNoResponse);
  }
}