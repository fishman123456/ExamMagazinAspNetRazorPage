using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ExamMagazinAspNetRazorPage.Models
{
    // Таблица для связи товары - заказы
    public class ShopingCart
    {
        // id для базы данных
        [Column("IdOrderProduct_f")]
        public int Id { get; set; }
        // количество продуктов
        [Column("QuantityOrderProduct_f")]
        public int Quantity { get; set; }

       
        [JsonIgnore]
        public Order? Order { get; set; }
        public Product? Product { get; set; }
        public override string ToString()
        {
            return $"{Id} - {Quantity}";
        }
    }
}
