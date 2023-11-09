
using System.ComponentModel.DataAnnotations;

namespace snof.Dtos
{
    public class CreateProductDto
    {

        [Required]
        public string ProductName { get; set; } = string.Empty;
        public Guid CategoryId { get; set; }
    }
}