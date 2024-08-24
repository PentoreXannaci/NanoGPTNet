using Newtonsoft.Json;

namespace NanoGPTNet.Models.Request;

public class ImageRequest(string prompt, string model, int width, int height, int amount = 1, int batchSize = 1) : Base(prompt, model)
{
  [JsonProperty("width")]
  public int Width { get; set; } = width;
  
  [JsonProperty("height")]
  public int Height { get; set; } = height;

  [JsonProperty("nImages")]
  public int Amount { get; set; } = amount;

  [JsonProperty("batchSize")]
  public int BatchSize { get; set; } = batchSize;
}