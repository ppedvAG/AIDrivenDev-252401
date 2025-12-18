using OpenAI;
using OpenAI.Chat;
using MiniShop.Application.Ai;

namespace MiniShop.Infrastructure.Ai;

public sealed class OpenAiResponsesClient : ILlmClient
{
    private readonly OpenAIClient _client;
    private readonly string _model;

    public OpenAiResponsesClient(string apiKey, string model = "gpt-4o")
    {
        _client = new OpenAIClient(apiKey);
        _model = model;
    }

    public async Task<string> CompleteAsync(string systemPrompt, string userPrompt, CancellationToken ct = default)
    {
        var chatClient = _client.GetChatClient(_model);

        var messages = new List<ChatMessage>
        {
            new SystemChatMessage(systemPrompt),
            new UserChatMessage(userPrompt)
        };

        ChatCompletion completion = await chatClient.CompleteChatAsync(messages, cancellationToken: ct);

        if (completion.Content != null && completion.Content.Count > 0)
        {
            return completion.Content[0].Text;
        }

        // Debugging output if content is empty
        Console.WriteLine($"[OpenAIResponseClient] Warning: No content received. FinishReason: {completion.FinishReason}");
        
        return string.Empty;
    }
}
