using System;
using MiniShop.Domain;

namespace MiniShop.Application;

public class AddItemToCart
{
    public void Execute(
        Cart cart,
        Product product,
        int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be > 0");

        cart.AddItem(product.Id, quantity);
    }
}
