using Newtonsoft.Json;

namespace NanoGPTNet.Models.Request;

public class ImageAdvancedRequest(string prompt, string model, int width, int height, int amount = 1, string negativePrompt = "", int steps = 25, string samplerName = "", decimal scale = 1m) : ImageRequest(prompt, model, width, height, amount)
{
  [JsonProperty("negative_prompt")]
  public string NegativePrompt { get; set; } = negativePrompt;

  [JsonProperty("num_steps")]
  public int Steps { get; set; } = steps;

  [JsonProperty("resolution")]
  public string Resolution { get; set; } = $"{width}x{height}";

  [JsonProperty("sampler_name")]
  public string SamplerName { get; set; } = samplerName;

  [JsonProperty("scale")]
  public decimal Scale { get; set; } = scale;
}