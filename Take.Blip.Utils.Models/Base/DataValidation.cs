using Take.Blip.Utils.Models.Dtos;
using Take.Blip.Utils.Models.Validators.Interfaces;

namespace Take.Blip.Utils.Models.Base;

public abstract class DataValidator : IValidationResponse
{ 
  private bool _isValid;
  private string _input;
  private string _cleanedInput;

  protected bool IsValid => _isValid;

  public DataValidator(string input)
  {
    _input = input;
  }

  protected abstract string Cleaner(string input);
  protected abstract string Formatter(string cleanedInput);
  protected abstract bool Validator(string cleanedInput);
  protected virtual string Responser(string cleanedInput) => cleanedInput;
  
  private string CleanInput(Func<string, string> cleaner) 
  {
    _cleanedInput = cleaner(_input);

    return _cleanedInput; 
  }

  private string FormatInput(Func<string, string> formatter) =>
    _isValid ? formatter(_cleanedInput) : Constants.UNEXPECTED_INPUT;

  private bool ValidateInput(Func<string, bool> validator) => 
    validator(_cleanedInput);

  private string GetValue(Func<string, string> responser) =>
    _isValid ? responser(_cleanedInput) : Constants.UNEXPECTED_INPUT;

  public virtual BaseValidationResponse ProcessValidation() 
  {
    var cleanedInput = CleanInput(Cleaner);

    _isValid = ValidateInput(Validator);

    var formatted = FormatInput(Formatter);
    
    var value = GetValue(Responser);

    var data = new ValidationData 
    {
      Input = _input,
      IsValid = _isValid,
      Formatted = formatted,
      Value = value
    };

    var response = new ValidationResponse { Data = data };

    return response;
  }
}