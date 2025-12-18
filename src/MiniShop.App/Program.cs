using MiniShop.Domain;
using MiniShop.Application;
using MiniShop.Application.Ai;

var product = new Product(
    Guid.NewGuid(),
    "Coffee",
    "A hot beverage made from roasted coffee beans",
    true,
    new Price(2, "EUR")
);

var cart = new Cart(Guid.NewGuid());

var useCase = new AddItemToCart();

// Use Case ausführen 
useCase.Execute(cart, product, 5);

// Ergebnis anzeigen
Console.WriteLine("Cart contents:");
foreach (var item in cart.Items)
{
    Console.WriteLine($"- {item.ProductId} x {item.Quantity}");
}

// AI Client testen
String apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY") ?? throw new InvalidOperationException("OPENAI_API_KEY not set");
ILlmClient aiClient = new OpenAiResponsesClient(apiKey);

try 
{
    Console.WriteLine("\nTesting AI Client...");
    var response = await aiClient.CompleteAsync(
        "You are a helpful assistant.", 
        "Was ist die Hauptstadt von Frankreich?"
    );
    Console.WriteLine($"AI Response: {response}");
}
catch (Exception ex)
{
    Console.WriteLine($"AI Error: {ex.Message}");
}
