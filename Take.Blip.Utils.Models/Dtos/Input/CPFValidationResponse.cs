using Newtonsoft.Json;

namespace Take.Blip.Utils.Models.Dtos.Input;

public class CPFValidationResponse : ValidationData
{
  [JsonProperty("masked")]
  public string Masked { get; set; }

  // Composition
  public CPFValidationResponse(ValidationData data)
  {
      Formatted = data.Formatted;
      Input = data.Input;
      IsValid = data.IsValid;
      Value = data.Value;
  }
}