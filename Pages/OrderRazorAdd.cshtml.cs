using ExamMagazinAspNetRazorPage.Models;
using ExamMagazinAspNetRazorPage.Storage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExamMagazinAspNetRazorPage.Pages
{
  
    public class OrderRazorAddModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Order order { get; set; } = new();

        public OrderRazorAddModel(ApplicationDbContext db)
        {
            _db = db;
        }
       

        public async Task<IActionResult> OnPostAsync()
        {
            await _db.Orders_t.AddAsync(order);
            await _db.SaveChangesAsync();
            return RedirectToPage("OrderRazor"); // перенаправление запроса на список заказов
        }
    }
}
