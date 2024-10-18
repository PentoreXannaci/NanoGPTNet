using Newtonsoft.Json;

namespace NanoGPTNet.Models.Request;

public class ImageRequest(string prompt, string model) : RequestBase(prompt, model)
{
  [JsonExtensionData]
  public Dictionary<string, object?> AdditionalProperties { get; set; } = [];

  public object? this[string key]
  {
    get => AdditionalProperties.TryGetValue(key, out object? value) ? value : null;
    set => AdditionalProperties[key] = value;
  }
}