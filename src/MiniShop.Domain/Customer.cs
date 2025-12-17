using System.Collections.Generic;

namespace MiniShop.Domain;

public class Customer
{
    public string DisplayName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string DeliveryNote { get; set; } = string.Empty;
    public Cart? Cart { get; set; }
    public List<Order> Orders { get; set; } = new List<Order>();
}
