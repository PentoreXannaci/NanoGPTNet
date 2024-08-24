using Newtonsoft.Json;

namespace NanoGPTNet.Models.Request;

public class RequestBase(string prompt, string model)
{
  [JsonProperty("prompt")]
  public string Prompt { get; set; } = prompt;

  [JsonProperty("model")]
  public string Model { get; } = model;
}