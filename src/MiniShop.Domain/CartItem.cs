using System;

namespace MiniShop.Domain;

public class CartItem
{
    public Guid ProductId { get; }
    public int Quantity { get; private set; }

    public CartItem(Guid productId, int quantity)
    {
        if (quantity <= 0) throw new ArgumentException("Quantity must be > 0");
        ProductId = productId;
        Quantity = quantity;
    }

    public void Increase(int amount)
    {
        if (amount <= 0) throw new ArgumentException("Increase must be > 0");
        Quantity += amount;
    }
}
