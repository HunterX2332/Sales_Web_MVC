using Sales_Web_MVC.Data;
using Sales_Web_MVC.Models;
using System.Linq;
using System.Collections.Generic;

namespace Sales_Web_MVC.Services
{
    public class DepartmentService
    {
        private readonly Sales_Web_MVCContext _context;
        public DepartmentService(Sales_Web_MVCContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
