using ExamMagazinAspNetRazorPage.Models;
using ExamMagazinAspNetRazorPage.Storage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExamMagazinAspNetRazorPage.Pages
{
    public class ProductRazorAddModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Product Product { get; set; } = new();

        public ProductRazorAddModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _db.Products_t.AddAsync(Product);
            await _db.SaveChangesAsync();
            return RedirectToPage("ProductRazor"); // перенаправление запроса на список продуктов
        }
    }
}
