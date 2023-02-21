using Newtonsoft.Json;

namespace Take.Blip.Utils.Models.Dtos.Input;

public sealed class YesOrNoValidationResponse : ValidationData
{
  [JsonProperty("decision")]
  public bool Decision { get; set; }

  public YesOrNoValidationResponse(ValidationData baseData) : base(baseData)
  {
  }
}