using Newtonsoft.Json;

namespace NanoGPTNet.Models.Response;

public class ImageContent
{
  [JsonProperty("b64_json")] 
  public string ImageBase64 { get; set; } = string.Empty;

  [JsonProperty("revised_prompt")] 
  public string RevisedPrompt { get; set; } = string.Empty;
}