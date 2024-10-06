using ExamMagazinAspNetRazorPage.Models;

namespace ExamMagazinAspNetRazorPage.Service
{
    public interface IClient
    {
        Task<Client?> Add(Client client);


        Task<Client?> GetById(int id);


        Task<List<Client>> ListAll();


        Task<Client?> RemoveById(int id);


        Task<Client?> UpdateById(int id, Client Client);
    }
}
