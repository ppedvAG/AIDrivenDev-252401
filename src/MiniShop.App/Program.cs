using MiniShop.Domain;
using MiniShop.Application;

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
