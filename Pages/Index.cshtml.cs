using ExamMagazinAspNetRazorPage.Models;
using ExamMagazinAspNetRazorPage.Storage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExamMagazinAspNetRazorPage.Pages
{
    public class IndexModel : PageModel
    {

        private readonly ApplicationDbContext _db;
        public List<string> basket = new List<string>();
        public List<Product> products { get; private set; } = new();
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(string name)
        {
            products = _db.Products_t.ToList();
            string str = basket.ToString();
        }
    }
}
