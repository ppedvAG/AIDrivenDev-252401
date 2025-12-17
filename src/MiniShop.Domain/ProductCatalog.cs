using System;
using System.Collections.Generic;

namespace MiniShop.Domain;

public class ProductCatalog
{
    public string Name { get; set; } = string.Empty;
    public DateTime ValidFrom { get; set; }
    public DateTime ValidTo { get; set; }
    public List<Product> Products { get; set; } = new List<Product>();
}
