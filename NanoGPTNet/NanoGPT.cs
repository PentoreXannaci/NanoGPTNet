using System.Text;
using System.Text.RegularExpressions;
using NanoGPTNet.Models.Request;
using NanoGPTNet.Models.Response;
using Newtonsoft.Json;

namespace NanoGPTNet;

public class NanoGPT
{
  private readonly HttpClient _client;
  public NanoGPT(string apiKey)
  {
    _client = new HttpClient();
    _client.BaseAddress = new Uri("https://nano-gpt.com/api/");
    _client.DefaultRequestHeaders.Add("x-api-key", apiKey);
  }

  public async Task<ChatResponse> ChatAsync(ChatRequest chat)
  {
    if (chat.Model.ToLower().Contains("gemini"))
    {
      return await PostRequestAsync<ChatResponse>("talk-to-gemini", chat);
    }
    else
    {
      return await PostRequestAsync<ChatResponse>("talk-to-gpt", chat);
    }
  }

  public async Task<ImageResponse> ImageAsync(ImageRequest image)
  {
    return await PostRequestAsync<ImageResponse>("generate-image", image);
  }

  public async Task<BalanceResponse> BalanceAsync()
  {
    return await PostRequestAsync<BalanceResponse>("check-nano-balance", null);
  }

  public async Task<NanoPriceResponse> NanoPriceAsync()
  {
    return await GetRequestAsync<NanoPriceResponse>("get-nano-price");
  }

  private async Task<T> PostRequestAsync<T>(string url, object? payload)
  {
    StringContent? body = null;
    if (payload != null)
    {
      var jsonPayload = JsonConvert.SerializeObject(payload);
      body = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
    }

    var response = await _client.PostAsync(url, body);

    if (!response.IsSuccessStatusCode)
    {
      var message = await response.Content.ReadAsStringAsync();
      throw new HttpRequestException($"request was not successful, StatusCode: {response.StatusCode}, \nResponse: {message}");
    }

    var content = await response.Content.ReadAsStringAsync();
    if (string.IsNullOrEmpty(content))
    {
      throw new NullReferenceException("request response is empty");
    }

    if (typeof(T) == typeof(ChatResponse))
    {
      // extract the nanoGPT tag, and parse its content.
      var match = Regex.Match(content, @"^(.*?)(<NanoGPT>([\s\S]*?)</NanoGPT>)", RegexOptions.Singleline);
      if (!match.Success)
      {
        throw new InvalidOperationException("The response does not contain a valid <NanoGPT> tag.");
      }

      var message = match.Groups[1].Value.Trim();
      var json = match.Groups[3].Value.Trim();
      var nanoResponse = JsonConvert.DeserializeObject<NanoGPTResponse>(json);
      if (nanoResponse == null)
      {
        throw new InvalidOperationException("The response does not contain a valid JSON inside the <NanoGPT> tag.");
      }
      return (T)(object)new ChatResponse(message, nanoResponse);
    }

    if (typeof(T) == typeof(ImageResponse))
    {
      return JsonConvert.DeserializeObject<T>(content) ?? throw new InvalidOperationException("invalid image response JSON.");
    }

    if (typeof(T) == typeof(BalanceResponse))
    {
      return JsonConvert.DeserializeObject<T>(content) ?? throw new InvalidOperationException("invalid balance response JSON.");
    }

    throw new NotSupportedException();
  }

  private async Task<T> GetRequestAsync<T>(string url)
  {
    var response = await _client.GetAsync(url);

    if (!response.IsSuccessStatusCode)
    {
      var message = await response.Content.ReadAsStringAsync();
      throw new HttpRequestException($"request was not successful, StatusCode: {response.StatusCode}, \nResponse: {message}");
    }

    var content = await response.Content.ReadAsStringAsync();
    if (string.IsNullOrEmpty(content))
    {
      throw new NullReferenceException("request response is empty");
    }

    return JsonConvert.DeserializeObject<T>(content) ?? throw new InvalidOperationException("invalid GET response JSON.");
  }
}