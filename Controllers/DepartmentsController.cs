using Microsoft.AspNetCore.Mvc;
using Sales_Web_MVC.Models;
using System.Collections.Generic;

namespace Sales_Web_MVC.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            List<Department> list = new List<Department>();
            list.Add(new Department { Id = 1, Name = "Eletronics" });
            list.Add(new Department { Id = 2, Name = "Fashion" });

            return View(list);
        }
    }
}
