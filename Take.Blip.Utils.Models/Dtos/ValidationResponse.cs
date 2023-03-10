using Newtonsoft.Json;

namespace Take.Blip.Utils.Models.Dtos;

/// <summary>
/// BlipData model class.
/// </summary>
public class BaseValidationResponse
{
  /// <summary>
  /// Data identifier
  /// </summary>
  [JsonProperty("id")]
  public Guid Id => Guid.NewGuid();

  /// <summary>
  /// Datetime when the response was generated (GMT-0).
  /// </summary>
  [JsonProperty("requested_at")]
  public RequestAt RequestedAt => new RequestAt();
}

public class ValidationResponse : BaseValidationResponse
{
  /// <summary>
  /// Formatted and validated data.
  /// </summary>
  [JsonProperty("data")]
  public ValidationData Data { get; set; }
}

public class ValidationResponse<T> : BaseValidationResponse where T : ValidationData
{
  public ValidationResponse()
  {
    
  }

  public ValidationResponse(T data)
  {
    Data = data;
  }

  [JsonProperty("data")]
  public T Data { get; set; }
}