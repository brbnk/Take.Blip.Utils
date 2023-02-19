using Newtonsoft.Json;

namespace Take.Blip.Utils.Models.Base;

public abstract class DataValidation
{
  protected const string UNEXPECTED_INPUT = "input inesperado";
  
  protected string _cleanedInput;
  private bool _isValid;
  private string _input;
  private string _formatted;
  private string _value;

  public DataValidation(string input)
  {
    _input = input;
    _cleanedInput = CleanInput(input);
    _isValid = ValidateData(_cleanedInput);
    _formatted = FormatData(_cleanedInput);
    _value = GetValue(_cleanedInput);
  }

  /// <summary>
  /// Input sent by blip user
  /// </summary>
  [JsonProperty("input")]
  public string Input => _input;

  /// <summary>
  /// Sanitized input
  /// </summary>
  [JsonProperty("cleaned")]
  public string CleanedInput => _cleanedInput;

  /// <summary>
  /// Value to be used on blip
  /// </summary>
  [JsonProperty("value")]
  public string Value => _value;

  /// <summary>
  /// Data validation
  /// </summary>
  [JsonProperty("isValid")]
  public bool IsValid => _isValid;

  /// <summary>
  /// Formatted data
  /// </summary>
  [JsonProperty("formatted")]
  public string Formatted => _formatted;
  
  protected abstract bool ValidateData(string cleanedInput);
  protected abstract string FormatData(string cleanedInput);
  protected abstract string GetValue(string cleanedInput);
  protected virtual string CleanInput(string input) => input.Trim();
}