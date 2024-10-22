using ExamMagazinAspNetRazorPage.Models;
using ExamMagazinAspNetRazorPage.Storage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ExamMagazinAspNetRazorPage.Pages
{
    public class ProductRazorDeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public ProductRazorDeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Product? removeble = await _db.Products_t.FirstOrDefaultAsync(c => c.Id == id);
            if (removeble != null)
            {
                _db.Products_t.Remove(removeble);
                await _db.SaveChangesAsync();
            }
            return RedirectToPage("ClientRazor");
        }
    }
}
