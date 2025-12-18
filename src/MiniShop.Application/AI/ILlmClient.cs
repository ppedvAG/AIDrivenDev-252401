namespace MiniShop.Application.Ai;

public interface ILlmClient
{
    Task<string> CompleteAsync(string systemPrompt, string userPrompt, CancellationToken ct = default);
}
