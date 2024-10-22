using ExamMagazinAspNetRazorPage.Models;
using ExamMagazinAspNetRazorPage.Storage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ExamMagazinAspNetRazorPage.Pages
{
    public class OrderRazorDeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public OrderRazorDeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Order? removeble = await _db.Orders_t.FirstOrDefaultAsync(c => c.Id == id);
            if (removeble != null)
            {
                _db.Orders_t.Remove(removeble);
                await _db.SaveChangesAsync();
            }
            return RedirectToPage("OrderRazor");
        }
    }
}
