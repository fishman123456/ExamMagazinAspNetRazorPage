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
        public Order orders { get; private set; } = new();
        public ClientRazorAddModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public string result = from Client in db.
                     join company in db.Companies on phone.CompanyId equals company.Id
                     join country in db.Countries on company.CountryId equals country.Id
                     select new
                     {
                         Name = phone.Name,
                         Company = company.Name,
                         Price = phone.Price,
                         Country = country.Name
                     };
        
        public async Task<IActionResult> OnPostAsync()
        {
            await _db.Clients_t.AddAsync(clients);
            await _db.SaveChangesAsync();
            return RedirectToPage(""); // перенаправление запроса на список клиентов
        }
    }
}
    

