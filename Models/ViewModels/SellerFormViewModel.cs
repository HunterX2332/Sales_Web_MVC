using System.Collections.Generic;

namespace Sales_Web_MVC.Models.ViewModels
{
    public class SellerFormViewModel
    {
        public Seller Seller {  get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}
