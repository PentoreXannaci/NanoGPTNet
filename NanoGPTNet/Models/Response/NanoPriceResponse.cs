namespace NanoGPTNet.Models.Response;

public class NanoPriceResponse
{
  public string Pair { get; set; } = string.Empty;
  public decimal LatestPrice { get; set; }
}