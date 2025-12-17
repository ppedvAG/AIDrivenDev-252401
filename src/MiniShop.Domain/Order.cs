using System;
using System.Collections.Generic;

namespace MiniShop.Domain;

public class Order
{
    public DateTime OrderDate { get; set; }
    public string Status { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public List<OrderLine> Lines { get; set; } = new List<OrderLine>();
}
