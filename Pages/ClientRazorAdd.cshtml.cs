using ExamMagazinAspNetRazorPage.Models;
using ExamMagazinAspNetRazorPage.Storage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExamMagazinAspNetRazorPage.Pages
{
    public class ClientRazorAddModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Client clients { get; private set; } = new();
        public ClientRazorAddModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _db.Clients_t.AddAsync(clients);
            await _db.SaveChangesAsync();
            return RedirectToPage("Page/Index"); // перенаправление запроса на список клиентов
        }
    }
}
    

