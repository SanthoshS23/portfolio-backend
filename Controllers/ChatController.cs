using System.Text;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Api.Models;

namespace Portfolio.Api.Controllers;

[ApiController]
[Route("api/chat")]
public class ChatController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly HttpClient _httpClient;

    public ChatController(
        IConfiguration configuration,
        IHttpClientFactory httpClientFactory)
    {
        _configuration = configuration;
        _httpClient = httpClientFactory.CreateClient();
    }

    [HttpPost("stream")]
    public async Task Stream(
        [FromBody] ChatRequest request,
        CancellationToken cancellationToken)
    {
        Response.Headers.Append("Content-Type", "text/event-stream");
        Response.Headers.Append("Cache-Control", "no-cache");
        Response.Headers.Append("Connection", "keep-alive");

        var apiKey = _configuration["Gemini:ApiKey"];

        if (string.IsNullOrWhiteSpace(apiKey))
        {
            Response.StatusCode = 500;

            await Response.WriteAsync(
                "event: error\ndata: Gemini API Key Missing\n\n",
                cancellationToken);

            return;
        }

        var payload = $$"""
        {
          "contents": [
            {
              "parts": [
                {
                  "text": "{{request.Message}}"
                }
              ]
            }
          ]
        }
        """;

        var geminiRequest = new HttpRequestMessage(
            HttpMethod.Post,
            $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash:streamGenerateContent?alt=sse&key={apiKey}");

        geminiRequest.Content =
            new StringContent(
                payload,
                Encoding.UTF8,
                "application/json");

        var geminiResponse =
            await _httpClient.SendAsync(
                geminiRequest,
                HttpCompletionOption.ResponseHeadersRead,
                cancellationToken);

        if (!geminiResponse.IsSuccessStatusCode)
        {
            var error =
                await geminiResponse.Content.ReadAsStringAsync(
                    cancellationToken);

            Response.StatusCode = 500;

            await Response.WriteAsync(
                $"event: error\ndata: {error}\n\n",
                cancellationToken);

            return;
        }

        await using var geminiStream =
            await geminiResponse.Content.ReadAsStreamAsync(
                cancellationToken);

        using var reader =
            new StreamReader(geminiStream);

        while (!reader.EndOfStream &&
               !cancellationToken.IsCancellationRequested)
        {
            var line =
                await reader.ReadLineAsync(cancellationToken);

            if (string.IsNullOrWhiteSpace(line))
                continue;

            if (!line.StartsWith("data:"))
                continue;

            try
            {
                var json =
                    line.Replace("data:", "").Trim();

                using var document =
                    System.Text.Json.JsonDocument.Parse(json);

                var root = document.RootElement;

                if (!root.TryGetProperty(
                        "candidates",
                        out var candidates))
                    continue;

                var text =
                    candidates[0]
                    .GetProperty("content")
                    .GetProperty("parts")[0]
                    .GetProperty("text")
                    .GetString();

                if (string.IsNullOrWhiteSpace(text))
                    continue;

                await Response.WriteAsync(
                    $"data: {text}\n\n",
                    cancellationToken);

                await Response.Body.FlushAsync(
                    cancellationToken);
            }
            catch
            {
                // Ignore malformed chunks
            }
        }

        await Response.WriteAsync(
            "event: done\ndata: completed\n\n",
            cancellationToken);

        await Response.Body.FlushAsync(
            cancellationToken);
    }
}