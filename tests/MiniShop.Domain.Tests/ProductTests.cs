using System;
using Xunit;
using MiniShop.Domain;

namespace MiniShop.Domain.Tests;

public class ProductTests
{
    [Fact]
    public void Constructor_SetsPropertiesCorrectly()
    {
        // Arrange
        var id = Guid.NewGuid();
        var name = "Test Product";
        var description = "Test Description";
        var availability = true;
        var price = new Price(10.99m, "USD");

        // Act
        var product = new Product(id, name, description, availability, price);

        // Assert
        Assert.Equal(id, product.Id);
        Assert.Equal(name, product.Name);
        Assert.Equal(description, product.Description);
        Assert.Equal(availability, product.Availability);
        Assert.Equal(price, product.Price);
    }

    [Fact]
    public void DefaultConstructor_SetsDefaults()
    {
        // Act
        var product = new Product();

        // Assert
        Assert.Equal(Guid.Empty, product.Id);
        Assert.Equal(string.Empty, product.Name);
        Assert.Equal(string.Empty, product.Description);
        Assert.False(product.Availability);
        Assert.NotNull(product.Price);
    }
}
