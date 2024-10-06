using ExamMagazinAspNetRazorPage.Models;
using ExamMagazinAspNetRazorPage.Service;
using ExamMagazinAspNetRazorPage.DB;
using Microsoft.EntityFrameworkCore;
using ExamMagazinAspNetRazorPage.Storage;

namespace ExamMagazinAspNetRazorPage.Storage;


    public class RdbProductService : IProductService
{
    private readonly ApplicationDbContext _db;

    public RdbProductService(ApplicationDbContext db)
    {
        _db = db;
    }
    public async Task<Product?> Add(Product product)
    {
        _db.Products_t.Add(product);
        await _db.SaveChangesAsync();
        return product;
    }

    public Task<Product?> GetById(int id)
    {
        return _db.Products_t.FirstOrDefaultAsync(product => product.Id == id);
    }

    public async Task<List<Product>> ListAll()
    {
        return await _db.Products_t.ToListAsync();
    }

    public async Task<Product?> RemoveById(int id)
    {
        Product? removed = await _db.Products_t.FirstOrDefaultAsync(product => product.Id == id);
        if (removed != null)
        {
            _db.Products_t.Remove(removed);
            await _db.SaveChangesAsync();
        }
        return removed;
    }

    public async Task<Product?> UpdateById(int id, Product product)
    {
        Product? update = await _db.Products_t.FirstOrDefaultAsync(product => product.Id == id);
        if (update != null)
        {
            update.Number = product.Number;
            update.Name = product.Name;
            update.Quantity = product.Quantity;
            update.Price = product.Price;

            await _db.SaveChangesAsync();
        }
        return update;
    }
}
