using ExamMagazinAspNetRazorPage.Models;
using ExamMagazinAspNetRazorPage.Storage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ExamMagazinAspNetRazorPage.Pages
{
    public class ClientRazorEditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]

        public Client Client { get; set; } = new();

        public ClientRazorEditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Client? client = await _db.Clients_t.FirstOrDefaultAsync(c => c.Id == id);
            if (client == null)
            {
                return NotFound();
            }
            Client = client;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Client? update = await _db.Clients_t.FirstOrDefaultAsync(c => c.Id == Client.Id);
            if (update == null)
            {
                return NotFound();
            }
            update.Name = Client.Name;
            update.LastName = Client.LastName;
            update.Email = Client.Email;
            await _db.SaveChangesAsync();
            return RedirectToPage("ClientRazor");
        }
    }
}
