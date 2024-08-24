using Newtonsoft.Json;

namespace NanoGPTNet.Models.Request;

public class ChatRequest(string prompt, string model, List<Message>? messages = null) : Base(prompt, model)
{
  [JsonProperty("messages")]
  public List<Message> Messages { get; set; } = messages ?? [];
}