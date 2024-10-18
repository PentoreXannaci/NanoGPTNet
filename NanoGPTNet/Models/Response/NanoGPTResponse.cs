namespace NanoGPTNet.Models.Response;

public class NanoGPTResponse
{
  public decimal Cost { get; set; }
  public int InputTokens { get; set; }
  public int OutputTokens { get; set; }
  public string PaymentSource { get; set; } = string.Empty;
}