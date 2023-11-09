using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using snof.Data;
using snof.Dtos;
using snof.Model;

namespace snof.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdcutController : ControllerBase
    {

        private AppDbContext _context;
        

        public ProdcutController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public ActionResult<List<Product>> Get()
        {
            List<Product> products = _context.Products
            .Include(c => c.Category)
            .Select(p => new Product()
            {
                Name = p.Name,
                Category = p.Category,
                Id = p.Id,
                CategoryId = p.CategoryId
            })
            .ToList();
            return Ok(products);
        }


        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProductDto productDto)
        {

            Category? category = _context.Categories
            .Find(productDto.CategoryId);
            if (category is null)
                return NotFound("Category not found");

            Product product = new()
            {
                Name = productDto.ProductName,
                CategoryId = productDto.CategoryId,
                Category = category
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return Ok(product);
        }


        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> UpdateProduct(Guid id, CreateProductDto productDto)
        {
            Product? product = await _context.Products.FindAsync(id);

            if (product is null)
                return NotFound("Product not found");
            product.Name = productDto.ProductName;

            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return Ok(product);
        }






        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            Product? product = await _context.Products.FindAsync(id);
            if (product is null)
                return NotFound("Product not found");
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return Ok("Deleted");
        }


    }
}