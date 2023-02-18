using Newtonsoft.Json;

namespace Take.Blip.Utils.Models.Base;

/// <summary>
/// BlipData model class.
/// </summary>
public class Response<T> where T : DataValidation
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
  public T Data { get; set; }

  /// <summary>
  /// Datetime when the response was generated (GMT-0).
  /// </summary>
  [JsonProperty("requested_at")]
  public DateTime RequestedAt => DateTime.UtcNow;
}