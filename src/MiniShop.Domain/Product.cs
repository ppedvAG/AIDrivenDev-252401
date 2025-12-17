namespace MiniShop.Domain;

public class Product
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool Availability { get; set; }
    public Price Price { get; set; } = new Price();
}
