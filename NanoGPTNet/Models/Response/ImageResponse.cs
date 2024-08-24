using Newtonsoft.Json;

namespace NanoGPTNet.Models.Response;

public class ImageResponse
{
  public long Created { get; set; }

  [JsonProperty("data")]
  public List<ImageContent> Images { get; set; } = [];
  public decimal NanoCost { get; set; }
  public decimal RemainingBalance { get; set; }
}