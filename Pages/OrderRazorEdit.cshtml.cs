using ExamMagazinAspNetRazorPage.Models;
using ExamMagazinAspNetRazorPage.Storage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ExamMagazinAspNetRazorPage.Pages
{
    public class OrderRazorEditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]

        public Order Order { get; set; } = new();

        public OrderRazorEditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Order? order = await _db.Orders_t.FirstOrDefaultAsync(c => c.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            Order = order;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Order? update = await _db.Orders_t.FirstOrDefaultAsync(c => c.Id == Order.Id);
            if (update == null)
            {
                return NotFound();
            }
            update.ÑodeOrder = Order.ÑodeOrder;
            update.CreatationDate = DateTime.Now;
            update.Client = Order.Client;
            await _db.SaveChangesAsync();
            return RedirectToPage("OrderRazor");
        }
    }
}
