namespace NanoGPTNet.Models.Response;

public class ChatResponse(string message, NanoGPTResponse nanoGPTResponse)
{
  public string Message { get; } = message;
  public NanoGPTResponse NanoGPT { get; } = nanoGPTResponse;
}