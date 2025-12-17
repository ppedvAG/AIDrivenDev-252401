using System;

namespace MiniShop.Domain;

public class CartItem
{
    public int Quantity { get; set; }
    public DateTime AddedAt { get; set; }
    public string Note { get; set; } = string.Empty;
    public Product Product { get; set; } = new Product();
}
