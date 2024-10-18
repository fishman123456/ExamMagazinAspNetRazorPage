using ExamMagazinAspNetRazorPage.Models;
using ExamMagazinAspNetRazorPage.Storage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExamMagazinAspNetRazorPage.Pages
{
    public class OrderRazorModel : PageModel
    {

           private readonly ApplicationDbContext _db;
        public List<Order> orders { get; private set; } = new();
        public OrderRazorModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(string name)
        {
            orders = _db.Orders_t.ToList();
        }
    }
    }
