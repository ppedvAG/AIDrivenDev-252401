using System;
using System.Linq;
using Xunit;
using MiniShop.Domain;

namespace MiniShop.Domain.Tests;

public class CartTests
{
    [Fact]
    public void AddItem_WithValidQuantity_AddsNewItem()
    {
        // Arrange
        var cart = new Cart(Guid.NewGuid());
        var productId = Guid.NewGuid();
        var quantity = 5;

        // Act
        cart.AddItem(productId, quantity);

        // Assert
        Assert.Single(cart.Items);
        var item = cart.Items.First();
        Assert.Equal(productId, item.ProductId);
        Assert.Equal(quantity, item.Quantity);
    }

    [Fact]
    public void AddItem_WithExistingItem_IncreasesQuantity()
    {
        // Arrange
        var cart = new Cart(Guid.NewGuid());
        var productId = Guid.NewGuid();
        cart.AddItem(productId, 5);

        // Act
        cart.AddItem(productId, 3);

        // Assert
        Assert.Single(cart.Items);
        var item = cart.Items.First();
        Assert.Equal(productId, item.ProductId);
        Assert.Equal(8, item.Quantity);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void AddItem_WithInvalidQuantity_ThrowsArgumentException(int quantity)
    {
        // Arrange
        var cart = new Cart(Guid.NewGuid());
        var productId = Guid.NewGuid();

        // Act & Assert
        Assert.Throws<ArgumentException>(() => cart.AddItem(productId, quantity));
    }
}
