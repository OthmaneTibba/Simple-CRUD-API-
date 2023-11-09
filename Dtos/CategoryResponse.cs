using snof.Model;

namespace snof.Dtos
{
    public class CategoryResponse
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public List<Product> Products { get; set; } = new();
    }
}