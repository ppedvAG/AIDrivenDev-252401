using System;
using Xunit;
using MiniShop.Domain;
using System.Linq;

namespace MiniShop.Application;

public class AddItemToCartTest
{
    [Fact]
    public void Execute_WithValidQuantity_AddsItemToCart()
    {
        // Arrange
        var cartId = Guid.NewGuid();
        var cart = new Cart(cartId);
        
        var productId = Guid.NewGuid();
        var product = new Product(productId, "Test Product", "Description", true, new Price(10, "USD"));
        
        var quantity = 5;
        var sut = new AddItemToCart();

        // Act
        sut.Execute(cart, product, quantity);

        // Assert
        Assert.Single(cart.Items);
        var item = cart.Items.First();
        Assert.Equal(productId, item.ProductId);
        Assert.Equal(quantity, item.Quantity);
    }

    [Fact]
    public void Execute_WithZeroQuantity_ThrowsArgumentException()
    {
        // Arrange
        var cart = new Cart(Guid.NewGuid());
        var product = new Product(Guid.NewGuid(), "Test", "Desc", true, new Price(10, "USD"));
        var sut = new AddItemToCart();

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => 
            sut.Execute(cart, product, 0));
        Assert.Equal("Quantity must be > 0", exception.Message);
    }

    [Fact]
    public void Execute_WithNegativeQuantity_ThrowsArgumentException()
    {
        // Arrange
        var cart = new Cart(Guid.NewGuid());
        var product = new Product(Guid.NewGuid(), "Test", "Desc", true, new Price(10, "USD"));
        var sut = new AddItemToCart();

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => 
            sut.Execute(cart, product, -1));
        Assert.Equal("Quantity must be > 0", exception.Message);
    }
}