
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace snof.Model
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        public required string Name { get; set; } = string.Empty;
        public Guid CategoryId { get; set; }
        [NotMapped]
        public Category? Category { get; set; }

    }
}