using Newtonsoft.Json;

namespace NanoGPTNet.Models.Request;

public class Message(string role, string content)
{
  [JsonProperty("role")]
  public string Role { get; set; } = role;

  [JsonProperty("content")]
  public string Content { get; set; } = content;
}