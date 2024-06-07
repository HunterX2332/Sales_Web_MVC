using Sales_Web_MVC.Data;
using Sales_Web_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Sales_Web_MVC.Services
{
    public class SalesRecordService
    {
        private readonly Sales_Web_MVCContext _context;
        public SalesRecordService(Sales_Web_MVCContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate) 
        {
            var result = from obj in _context.SalesRecord select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if(maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }
            return await result.Include(x => x.Seller).Include(x => x.Seller.Department).OrderByDescending(x => x.Date).ToListAsync();
        }
    }
}
