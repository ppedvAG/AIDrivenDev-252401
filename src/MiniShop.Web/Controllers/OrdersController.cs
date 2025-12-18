using Microsoft.AspNetCore.Mvc;

namespace MiniShop.Web.Controllers;

public class OrdersController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}
