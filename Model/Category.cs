
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace snof.Model
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        [NotMapped]
        public List<Product> Products { get; set; } = new();
    }
}