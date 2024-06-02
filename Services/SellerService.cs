using Sales_Web_MVC.Data;
using Sales_Web_MVC.Models;

namespace Sales_Web_MVC.Services
{
    public class SellerService
    {
        private readonly Sales_Web_MVCContext _context;
        public SellerService(Sales_Web_MVCContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj)
        { 
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
