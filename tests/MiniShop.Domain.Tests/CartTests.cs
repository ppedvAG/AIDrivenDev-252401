using System;
using System.Linq;
using Xunit;
using MiniShop.Domain;

namespace MiniShop.Domain.Tests;

public class CartTests
{
    [Fact]
    public void AddItem_WithNewItem_AddsToCart()
    {
        // Arrange
        var cart = new Cart(Guid.NewGuid());
        var productId = Guid.NewGuid();
        var quantity = 2;

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
        cart.AddItem(productId, 2);

        // Act
        cart.AddItem(productId, 3);

        // Assert
        Assert.Single(cart.Items);
        var item = cart.Items.First();
        Assert.Equal(productId, item.ProductId);
        Assert.Equal(5, item.Quantity);
    }

    [Fact]
    public void AddItem_WithZeroQuantity_ThrowsArgumentException()
    {
        // Arrange
        var cart = new Cart(Guid.NewGuid());
        var productId = Guid.NewGuid();

        // Act & Assert
        Assert.Throws<ArgumentException>(() => cart.AddItem(productId, 0));
    }

    [Fact]
    public void AddItem_WithNegativeQuantity_ThrowsArgumentException()
    {
        // Arrange
        var cart = new Cart(Guid.NewGuid());
        var productId = Guid.NewGuid();

        // Act & Assert
        Assert.Throws<ArgumentException>(() => cart.AddItem(productId, -1));
    }
}
