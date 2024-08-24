namespace NanoGPTNet.Models.Response;

public class NanoGPTResponse
{
  public decimal NanoCost { get; set; }
  public int InputTokens { get; set; }
  public int OutputTokens { get; set; }
}