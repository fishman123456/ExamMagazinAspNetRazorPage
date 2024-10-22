using ExamMagazinAspNetRazorPage.Models;
using ExamMagazinAspNetRazorPage.Storage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ExamMagazinAspNetRazorPage.Pages
{
    public class ProductRazorEditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]

        public Product Product { get; set; } = new();

        public ProductRazorEditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Product? product = await _db.Products_t.FirstOrDefaultAsync(c => c.Id == id);
            if (product == null)
            {
                return NotFound();
            }
           Product = product;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
           Product? update = await _db.Products_t.FirstOrDefaultAsync(c => c.Id == Product.Id);
            if (update == null)
            {
                return NotFound();
            }
            update.Number = Product.Number;
            update.Name = Product.Name;
            update.Quantity = Product.Quantity;
            update.Price = Product.Price;
            
            await _db.SaveChangesAsync();
            return RedirectToPage("ProductRazor");
        }
    }
}
