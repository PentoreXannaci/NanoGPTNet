using NanoGPTNet;
using NanoGPTNet.Models.Request;

var gpt = new NanoGPT("API_KEY");

var balanceResp = await gpt.BalanceAsync();
Console.WriteLine("           Balance: " + balanceResp.Balance);
Console.WriteLine("NanoDepositAddress: " + balanceResp.NanoDepositAddress);
Console.WriteLine(" NanoReturnAddress: " + balanceResp.NanoReturnAddress);
Console.WriteLine("        Receivable: " + balanceResp.Receivable);
Console.WriteLine("            Earned: " + balanceResp.Earned);
Console.WriteLine("\n-------------------------------------------\n");
await Task.Delay(250);

var nanoPrice = await gpt.NanoPriceAsync();
Console.WriteLine("       Pair: " + nanoPrice.Pair);
Console.WriteLine("LatestPrice: " + nanoPrice.LatestPrice);
Console.WriteLine("\n-------------------------------------------\n");
await Task.Delay(250);

#region chat

var chatGPT = await gpt.ChatAsync(new ChatRequest("Hey GPT whats up?", "chatgpt-4o-latest"));
Console.WriteLine("     Message: " + chatGPT.Message);
Console.WriteLine(" InputTokens: " + chatGPT.NanoGPT.InputTokens);
Console.WriteLine("OutputTokens: " + chatGPT.NanoGPT.OutputTokens);
Console.WriteLine("    NanoCost: " + chatGPT.NanoGPT.NanoCost);
Console.WriteLine("\n-------------------------------------------\n");
await Task.Delay(250);

var chatGemini = await gpt.ChatAsync(new ChatRequest("Hey Gemini whats up?", "gemini-1.5-pro-exp"));
Console.WriteLine("     Message: " + chatGemini.Message);
Console.WriteLine(" InputTokens: " + chatGemini.NanoGPT.InputTokens);
Console.WriteLine("OutputTokens: " + chatGemini.NanoGPT.OutputTokens);
Console.WriteLine("    NanoCost: " + chatGemini.NanoGPT.NanoCost);
Console.WriteLine("\n-------------------------------------------\n");
await Task.Delay(250);

var chatLama = await gpt.ChatAsync(new ChatRequest("Hey Lama whats up?", "llama-3.1-70b-instruct"));
Console.WriteLine("     Message: " + chatLama.Message);
Console.WriteLine(" InputTokens: " + chatLama.NanoGPT.InputTokens);
Console.WriteLine("OutputTokens: " + chatLama.NanoGPT.OutputTokens);
Console.WriteLine("    NanoCost: " + chatLama.NanoGPT.NanoCost);
Console.WriteLine("\n-------------------------------------------\n");
await Task.Delay(250);

#endregion

#region image

var imageDallE = await gpt.ImageAsync(new ImageRequest("King PentoreXannaci sitting in his Castle.", "dall-e-3", 512, 512));
Console.WriteLine("               Created: " + imageDallE.Created);
Console.WriteLine("      RemainingBalance: " + imageDallE.RemainingBalance);
Console.WriteLine("              NanoCost: " + imageDallE.NanoCost);
Console.WriteLine("          Images Count: " + imageDallE.Images.Count);
Console.WriteLine("Image[0].RevisedPrompt: " + imageDallE.Images.First().RevisedPrompt);
// Console.WriteLine("  Image[0].ImageBase64: " + imageDallE.Images.First().ImageBase64);
Console.WriteLine("\n-------------------------------------------\n");
await Task.Delay(250);

var imageFluxPro = await gpt.ImageAsync(new ImageRequest("King PentoreXannaci sitting in his Castle.", "flux-pro", 512, 512));
Console.WriteLine("               Created: " + imageFluxPro.Created);
Console.WriteLine("      RemainingBalance: " + imageFluxPro.RemainingBalance);
Console.WriteLine("              NanoCost: " + imageFluxPro.NanoCost);
Console.WriteLine("          Images Count: " + imageFluxPro.Images.Count);
Console.WriteLine("Image[0].RevisedPrompt: " + imageFluxPro.Images.First().RevisedPrompt);
// Console.WriteLine("  Image[0].ImageBase64: " + imageDallE.Images.First().ImageBase64);
Console.WriteLine("\n-------------------------------------------\n");
await Task.Delay(250);

var dreamShaper = await gpt.ImageAsync(new ImageRequest("King PentoreXannaci sitting in his Castle.", "dreamshaper_8_93211.safetensors", 512, 512, 2));
Console.WriteLine("               Created: " + dreamShaper.Created);
Console.WriteLine("      RemainingBalance: " + dreamShaper.RemainingBalance);
Console.WriteLine("              NanoCost: " + dreamShaper.NanoCost);
Console.WriteLine("          Images Count: " + dreamShaper.Images.Count);
Console.WriteLine("Image[0].RevisedPrompt: " + dreamShaper.Images.First().RevisedPrompt);
// Console.WriteLine("  Image[0].ImageBase64: " + imageDallE.Images.First().ImageBase64);
Console.WriteLine("\n-------------------------------------------\n");
await Task.Delay(250);

#endregion