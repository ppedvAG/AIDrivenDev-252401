using Microsoft.AspNetCore.Mvc;

namespace MiniShop.Web.Controllers;

public class ProductsController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}
