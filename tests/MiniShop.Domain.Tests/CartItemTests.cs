using System;
using Xunit;
using MiniShop.Domain;

namespace MiniShop.Domain.Tests;

public class CartItemTests
{
    [Fact]
    public void Constructor_WithValidArguments_CreatesInstance()
    {
        // Arrange
        var productId = Guid.NewGuid();
        var quantity = 5;

        // Act
        var item = new CartItem(productId, quantity);

        // Assert
        Assert.Equal(productId, item.ProductId);
        Assert.Equal(quantity, item.Quantity);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Constructor_WithInvalidQuantity_ThrowsArgumentException(int quantity)
    {
        // Arrange
        var productId = Guid.NewGuid();

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new CartItem(productId, quantity));
    }

    [Fact]
    public void Increase_WithValidAmount_IncreasesQuantity()
    {
        // Arrange
        var item = new CartItem(Guid.NewGuid(), 5);

        // Act
        item.Increase(3);

        // Assert
        Assert.Equal(8, item.Quantity);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Increase_WithInvalidAmount_ThrowsArgumentException(int amount)
    {
        // Arrange
        var item = new CartItem(Guid.NewGuid(), 5);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => item.Increase(amount));
    }
}
