using Microsoft.AspNetCore.Mvc;

namespace Sales_Web_MVC.Controllers
{
    public class SalesRecordsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SimpleSearch()
        {
            return View();
        }
        public IActionResult GroupingSearch()
        {
            return View();
        }
    }
}
