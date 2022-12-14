using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Cart()
        {
            return View();
        }
    }
}
