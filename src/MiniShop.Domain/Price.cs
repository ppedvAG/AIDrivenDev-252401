namespace MiniShop.Domain;

public class Price
{
    public Price() { }

    public Price(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public decimal Amount { get; set; }
    public string Currency { get; set; } = string.Empty;
}
