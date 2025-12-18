using Microsoft.AspNetCore.Mvc;
using MiniShop.Application;
using MiniShop.Domain;
using System;

namespace MiniShop.Web.Controllers;

public class CartController : Controller
{
    private readonly AddItemToCart _addItemToCart;

    // In a real app, we would persist the cart. For this demo, we'll use a static cart or create one on the fly.
    // To keep it simple and stateless as per "HTTP Requests annehmen -> Use Case aufrufen -> Ergebnisdarstellung",
    // we will create a fresh cart for the demo or simulate persistence.
    private static readonly Cart _demoCart = new Cart(Guid.NewGuid());

    public CartController(AddItemToCart addItemToCart)
    {
        _addItemToCart = addItemToCart;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View(_demoCart);
    }

    [HttpPost]
    public IActionResult Add(Guid productId, int quantity, string productName, decimal price)
    {
        // 1. Input validieren/umformen (Basic validation happens via model binding, but we can add more)
        if (quantity <= 0)
        {
            ModelState.AddModelError("Quantity", "Quantity must be greater than 0");
            return View("Index", _demoCart);
        }

        // Create a dummy product for the demo since we don't have a product repository yet
        var product = new Product(productId, productName ?? "Unknown Product", "Description", true, new Price(price, "EUR"));

        // 2. Use Case aufrufen
        try
        {
            _addItemToCart.Execute(_demoCart, product, quantity);
        }
        catch (ArgumentException ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            return View("Index", _demoCart);
        }

        // 3. Ergebnisdarstellung
        return RedirectToAction(nameof(Index));
    }
}
