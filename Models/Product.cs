using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ExamMagazinAspNetRazorPage.Models
{
    // Таблица товаров, карточка товара
    public class Product
    {
        // id для базы данных
        [Column("IdProduct_f")]
        public int Id { get; set; }
        // номер продукта потом найдем применение
        [Column("NumberProduct_f")]
        public string Number { get; set; }
        // имя товара
        [Column("NameProduct_f")]
        public string Name { get; set; }
        // количество товара
        [Column("QuantityProduct_f")]
        public int Quantity { get; set; }
        // цена за еденицу товара
        [Column("PriceUnitProduct_f")]
        public decimal Price { get; set; }


        [JsonIgnore]
        public ICollection<ShopingCart>? ShopingCarts { get; set; }
        public Product()
        {
            Number = string.Empty;
            Name = string.Empty;
            Quantity = 0;
        }

        public override string ToString()
        {
            return $"{Id} - {Name} - {Price} - {Quantity}";
        }
    }
}
