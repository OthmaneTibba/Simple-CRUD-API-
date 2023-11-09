using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using snof.Data;
using snof.Dtos;
using snof.Model;

namespace snof.Controllers
{


    [ApiController]
    [Route("api/[controller]")]

    public class CategoryController : ControllerBase
    {

        private readonly AppDbContext _context;
        private IMapper _mapper;

        public CategoryController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        [HttpGet]
        public IEnumerable<CategoryResponse> Get() => _context.Categories.Include(c => c.Products).Select(p => new CategoryResponse { CategoryName = p.CategoryName, Id = p.Id, Products = p.Products }).ToList();


        [HttpPost]
        public ActionResult<Category> CreateCategory(CreateCategoryDto categoryDto)
        {
            Category category = _mapper.Map<Category>(categoryDto);
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Ok(category);
        }

    }
}