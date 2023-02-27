using Newtonsoft.Json;

namespace Take.Blip.Utils.Models.Dtos;

public class RequestAt
{
  [JsonProperty("utc_date")]
  public DateTimeOffset UTC => 
    DateTimeOffset.UtcNow;

  [JsonProperty("utc_date_formatted")]
  public string UTCFormatted => 
    UTC.ToString(Constants.DEFAULT_DATETIME_FORMAT);

  [JsonProperty("gmt_minus3_date")]
  public DateTimeOffset GMTMinus3 => 
    DateTimeOffset.UtcNow.AddHours(-3);

  [JsonProperty("gmt_minus3_formatted")]
  public string GMTMinus3Formatted => 
    GMTMinus3.ToString(Constants.DEFAULT_DATETIME_FORMAT);
}