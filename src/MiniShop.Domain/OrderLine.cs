namespace MiniShop.Domain;

public class OrderLine
{
    public int Quantity { get; set; }
    public decimal LineAmount { get; set; }
    public Product Product { get; set; } = new Product();
}
