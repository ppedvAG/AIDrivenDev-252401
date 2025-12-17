namespace MiniShop.Domain;

public class Product
{
    public Product() { }

    public Product(Guid id, string name, string description, bool availability, Price price)
    {
        Id = id;
        Name = name;
        Description = description;
        Availability = availability;
        Price = price;
    }

    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool Availability { get; set; }
    public Price Price { get; set; } = new Price();
}
