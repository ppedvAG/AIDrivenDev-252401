using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MiniShop.Application.Ai;

public sealed class LocalLlmClient : ILlmClient
{
    private readonly HttpClient _httpClient;
    private readonly string _model;

    public LocalLlmClient(HttpClient httpClient, string model = "mistralai/ministral-3-3b")
    {
        _httpClient = httpClient;
        _model = model;
    }

    public async Task<string> CompleteAsync(string systemPrompt, string userPrompt, CancellationToken ct = default)
    {
        var request = new LocalLlmRequest
        {
            Model = _model,
            Input = userPrompt,
            Instructions = systemPrompt,
            Reasoning = new { effort = "low" }
        };

        var response = await _httpClient.PostAsJsonAsync("v1/responses", request, ct);
        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadFromJsonAsync<LocalLlmResponse>(cancellationToken: ct);

        if (result?.Output != null && result.Output.Count > 0)
        {
            var firstOutput = result.Output[0];
            if (firstOutput.Content != null && firstOutput.Content.Count > 0)
            {
                return firstOutput.Content[0].Text;
            }
        }

        return string.Empty;
    }

    private class LocalLlmRequest
    {
        [JsonPropertyName("model")]
        public string Model { get; set; } = string.Empty;

        [JsonPropertyName("input")]
        public string Input { get; set; } = string.Empty;

        [JsonPropertyName("instructions")]
        public string Instructions { get; set; } = string.Empty;

        [JsonPropertyName("reasoning")]
        public object? Reasoning { get; set; }
    }

    private class LocalLlmResponse
    {
        [JsonPropertyName("output")]
        public List<LocalLlmOutput>? Output { get; set; }
    }

    private class LocalLlmOutput
    {
        [JsonPropertyName("content")]
        public List<LocalLlmContent>? Content { get; set; }
    }

    private class LocalLlmContent
    {
        [JsonPropertyName("text")]
        public string Text { get; set; } = string.Empty;
    }
}
