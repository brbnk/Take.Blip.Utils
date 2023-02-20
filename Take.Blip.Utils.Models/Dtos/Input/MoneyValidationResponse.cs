using Newtonsoft.Json;

namespace Take.Blip.Utils.Models.Dtos.Input;

public sealed class MoneyValidationResponse : ValidationData
{
  [JsonProperty("truncated")]
  public string Truncated { get; set; }

  public MoneyValidationResponse(ValidationData baseData) : base(baseData)
  {
  }
}