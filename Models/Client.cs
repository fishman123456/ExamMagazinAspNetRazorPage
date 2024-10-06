using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ExamMagazinAspNetRazorPage.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class Client
    {
        [Column("IdClient_f")]
        public int Id { get; set; }

        [Column("ClientName_f")]
        public string Name { get; set; }

        [Column("ClientLast_f")]
        public string LastName { get; set; }

        [Column("ClientEmail_f")]
        public string Email { get; set; }

        // связь с таблицей заказы
        [JsonIgnore]
        public Order? Order { get; set; }
        public override string ToString()
        {
            return $"{Id} - {Name} - {LastName} - {Email}";
        }
    }
}
