using ExamMagazinAspNetRazorPage.Models;
using ExamMagazinAspNetRazorPage.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ExamMagazinAspNetRazorPage.Storage;

namespace ExamMagazinAspNetRazorPage.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public List<Client> clients { get; private set; } = new();
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(string name)
        {
            clients = _db.Clients_t.ToList();
        }
    }
}
