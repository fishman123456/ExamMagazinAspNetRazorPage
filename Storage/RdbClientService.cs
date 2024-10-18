using ExamMagazinAspNetRazorPage.Models;
using ExamMagazinAspNetRazorPage.Service;
using Microsoft.EntityFrameworkCore;

namespace ExamMagazinAspNetRazorPage.Storage
{
    public class RdbClientService : IClientService
    {
        private readonly ApplicationDbContext _db;

        public RdbClientService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Client?> Add(Client client)
        {
           _db.Clients_t.Add(client);
            await _db.SaveChangesAsync();
            return client;
        }

        public async Task<Client?> GetById(int id)
        {
            return await _db.Clients_t.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<Client>> ListAll()
        {
           return _db.Clients_t.ToListAsync();
        }

        public async Task<Client?> RemoveById(int id)
        {
           Client? removed = await _db.Clients_t.FirstOrDefaultAsync(client=> client.Id == id);
            if (removed != null)
            {
                _db.Clients_t.Remove(removed);
                await _db.SaveChangesAsync();
            }
            return removed;
        }

        public async Task<Client?> UpdateById(int id, Client client)
        {
            // обновляем всё кроме почты 07-10-2024
            Client? updated = await _db.Clients_t.FirstOrDefaultAsync(client => client.Id == id);
            if (updated != null)
            {
                updated.Name = client.Name;
                updated.LastName = client.LastName;
                updated.Email = client.Email;
                await _db.SaveChangesAsync();
            }
            return updated;
        }
    }
}
