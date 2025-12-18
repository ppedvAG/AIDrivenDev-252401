using Xunit;
using MiniShop.Domain;

namespace MiniShop.Domain.Tests;

public class PriceTests
{
    [Fact]
    public void Constructor_SetsPropertiesCorrectly()
    {
        // Arrange
        var amount = 19.99m;
        var currency = "EUR";

        // Act
        var price = new Price(amount, currency);

        // Assert
        Assert.Equal(amount, price.Amount);
        Assert.Equal(currency, price.Currency);
    }

    [Fact]
    public void DefaultConstructor_SetsDefaults()
    {
        // Act
        var price = new Price();

        // Assert
        Assert.Equal(0m, price.Amount);
        Assert.Equal(string.Empty, price.Currency);
    }
}
