using blog.api.Data;
using blog.api.Models.DTO;
using blog.api.Models.Entities;
using blog.api.Models.Files;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace blog.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly BlogDbContext dbContext;

        public CategoryController(BlogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetAllCategories()
        {
            var categories = await dbContext.Categories.ToListAsync();
            return Ok(categories);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> AddCategory(AddCategoryDto addCategory)
        {
            var category = new Category()
            {
                Name = addCategory.name
            };

            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();
            return Ok(category);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Category>> EditCategory([FromRoute] int id,Category editedCategory)
        {
            var category=await dbContext.Categories.FindAsync(id);
            if(category == null) { return NotFound(); }
            category.Name= editedCategory.Name;
            await dbContext.SaveChangesAsync();
            return Ok(category);
        }

    }
}
