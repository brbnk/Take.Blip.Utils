using Newtonsoft.Json;

namespace Take.Blip.Utils.Models.Base;

public abstract class DataValidation
{
  /// <summary>
  /// Input sent by blip user
  /// </summary>
  [JsonProperty("input")]
  public string BlipUserInput { get; private set; } 

  /// <summary>
  /// Data validation
  /// </summary>
  [JsonProperty("isValid")]
  public bool IsValid => ValidateData();

  /// <summary>
  /// Formatted data
  /// </summary>
  [JsonProperty("formatted")]
  public string Formatted => FormatData();

  protected void SetUserInput(string input) => BlipUserInput = input;
  protected abstract bool ValidateData();
  protected abstract string FormatData();
}