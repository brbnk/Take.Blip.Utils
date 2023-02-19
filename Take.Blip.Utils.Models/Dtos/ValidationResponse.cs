using Newtonsoft.Json;
using Take.Blip.Utils.Models.Base;

namespace Take.Blip.Utils.Models.Dtos;

/// <summary>
/// BlipData model class.
/// </summary>
public class ValidationResponse
{
  /// <summary>
  /// Data identifier
  /// </summary>
  [JsonProperty("id")]
  public Guid Id => Guid.NewGuid();

  /// <summary>
  /// Formatted and validated data.
  /// </summary>
  [JsonProperty("data")]
  public ValidationData Data { get; set; }

  /// <summary>
  /// Datetime when the response was generated (GMT-0).
  /// </summary>
  [JsonProperty("requested_at")]
  public RequestAt RequestedAt => new RequestAt();
}