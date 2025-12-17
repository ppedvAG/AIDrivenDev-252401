using System;
using System.Collections.Generic;

namespace MiniShop.Domain;

public class ShoppingCart
{
    public string Status { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime LastUpdatedAt { get; set; }
    public List<CartItem> Items { get; set; } = new List<CartItem>();
}
