using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sales_Web_MVC.Models;

namespace Sales_Web_MVC.Data
{
    public class Sales_Web_MVCContext : DbContext
    {
        public Sales_Web_MVCContext (DbContextOptions<Sales_Web_MVCContext> options)
            : base(options)
        {
        }

        public DbSet<Sales_Web_MVC.Models.Department> Department { get; set; } = default!;
    }
}
