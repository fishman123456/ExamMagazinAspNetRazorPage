using ExamMagazinAspNetRazorPage.Models;
using ExamMagazinAspNetRazorPage.Storage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExamMagazinAspNetRazorPage.Pages
{
    public class OrderProductRazorModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public List<OrderProduct> orderProducts { get; private set; } = new();
        public OrderProductRazorModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(string name)
        {
            orderProducts = _db.OrderProduct_t.ToList();
        }
    }
}
