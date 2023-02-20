using Newtonsoft.Json;

namespace Take.Blip.Utils.Models.Dtos;

public class ValidationData
{
  public ValidationData()
  {
  }

  public ValidationData(ValidationData data)
  {
    Input = data.Input;
    IsValid = data.IsValid;
    Formatted = data.Formatted;
    Value = data.Value;
  }

  [JsonProperty("input")]
  public string Input { get; set; }

  [JsonProperty("isValid")]
  public bool IsValid { get; set; }

  [JsonProperty("formatted")]
  public string Formatted { get; set; }

  [JsonProperty("value")]
  public string Value { get; set; }
}