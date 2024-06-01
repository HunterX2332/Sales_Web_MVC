using Microsoft.AspNetCore.Mvc;

namespace Sales_Web_MVC.Controllers
{
    public class SellersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
