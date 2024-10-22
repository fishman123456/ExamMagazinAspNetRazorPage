using ExamMagazinAspNetRazorPage.Models;
using ExamMagazinAspNetRazorPage.Storage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ExamMagazinAspNetRazorPage.Pages
{
    public class ClientRazorDeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public ClientRazorDeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Client? removeble = await _db.Clients_t.FirstOrDefaultAsync(c => c.Id == id);
            if (removeble != null)
            {
                _db.Clients_t.Remove(removeble);
                await _db.SaveChangesAsync();
            }
            return RedirectToPage("ClientRazor");
        }
    }
}
