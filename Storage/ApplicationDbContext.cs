using ExamMagazinAspNetRazorPage.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.SqlServer;

namespace ExamMagazinAspNetRazorPage.Storage
{
    public class ApplicationDbContext : DbContext
    {
        // создаём таблицу клиентов
        public DbSet<Client> Clients_t { get; set; }
        // создаём таблицу заказов
        public DbSet<Order> Orders_t { get; set; }
        // создаём таблицу связи клиентов закзазов
        public DbSet<ShopingCart> ShopingCarts_t { get; set; }
        // создаём таблицу продуктов
        public DbSet<Product> Products_t { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            string? connectionSring = configuration.GetConnectionString("LocalDbConnection");
            optionsBuilder.UseSqlServer(connectionSring);
        }
    }
}
