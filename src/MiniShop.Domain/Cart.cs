using System;
using System.Collections.Generic;
using System.Linq;

namespace MiniShop.Domain;

public class Cart
{
    public Guid Id { get; }
    private readonly List<CartItem> _items = new();
    public IReadOnlyList<CartItem> Items => _items;

    public Cart(Guid id) => Id = id;

    public void AddItem(Guid productId, int quantity)
    {
        if (quantity <= 0) throw new ArgumentException("Quantity must be > 0");

        var existing = _items.FirstOrDefault(x => x.ProductId == productId);
        if (existing is null)
            _items.Add(new CartItem(productId, quantity));
        else
            existing.Increase(quantity);
    }
}
