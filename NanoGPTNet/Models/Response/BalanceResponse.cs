namespace NanoGPTNet.Models.Response;

public class BalanceResponse
{
  public string NanoDepositAddress { get; set; } = string.Empty;
  public string NanoReturnAddress { get; set; } = string.Empty;
  public decimal Balance { get; set; }
  public decimal Receivable { get; set; }
  public string Earned { get; set; } = string.Empty;
}