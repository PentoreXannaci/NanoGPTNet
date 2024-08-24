using Newtonsoft.Json;

namespace NanoGPTNet.Models.Request;

public class Base(string prompt, string model)
{
  [JsonProperty("prompt")]
  public string Prompt { get; set; } = prompt;

  [JsonProperty("model")]
  public string Model { get; } = model;
}