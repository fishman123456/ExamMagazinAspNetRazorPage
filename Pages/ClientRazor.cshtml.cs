using ExamMagazinAspNetRazorPage.Models;
using ExamMagazinAspNetRazorPage.Storage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExamMagazinAspNetRazorPage.Pages
{
    public class ClientRazorModel : PageModel
    {

        private readonly ApplicationDbContext _db;
        public List<Client> clients { get; private set; } = new();
        public ClientRazorModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(string name)
        {
            clients = _db.Clients_t.ToList();
        }
    }
}
