using ExamMagazinAspNetRazorPage.Models;
using ExamMagazinAspNetRazorPage.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ExamMagazinAspNetRazorPage.Storage;

namespace ExamMagazinAspNetRazorPage.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IClientService _clientService;
        public string Message { get; }
        public IndexModel()
        {
            Message = "Hello METANIT.COM";
        }
        public async Task<List<Client>> ListAll()
        {
            return await _clientService.ListAll();
        }
        public string PrintTime() => DateTime.Now.ToShortTimeString();
    }
}
