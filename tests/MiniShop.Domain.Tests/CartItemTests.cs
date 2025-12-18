using System;
using Xunit;
using MiniShop.Domain;

namespace MiniShop.Domain.Tests;

public class CartItemTests
{
    [Fact]
    public void Constructor_WithValidArguments_CreatesItem()
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

    [Fact]
    public void Constructor_WithZeroQuantity_ThrowsArgumentException()
    {
        // Arrange
        var productId = Guid.NewGuid();

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new CartItem(productId, 0));
    }

    [Fact]
    public void Constructor_WithNegativeQuantity_ThrowsArgumentException()
    {
        // Arrange
        var productId = Guid.NewGuid();

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new CartItem(productId, -1));
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

    [Fact]
    public void Increase_WithZeroAmount_ThrowsArgumentException()
    {
        // Arrange
        var item = new CartItem(Guid.NewGuid(), 5);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => item.Increase(0));
    }

    [Fact]
    public void Increase_WithNegativeAmount_ThrowsArgumentException()
    {
        // Arrange
        var item = new CartItem(Guid.NewGuid(), 5);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => item.Increase(-1));
    }
}
