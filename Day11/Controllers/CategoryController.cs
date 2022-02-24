using Day11.DTO;
using Day11.Models;
using Day11.Service;
using Microsoft.AspNetCore.Mvc;

namespace Day11.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("/get-all-category")]
        public async Task<List<Category>> GettAllCategory()
        {
            return await _categoryService.GettAllCategory();
        }

        [HttpPost("/add-category")]
        public async Task Add([FromBody] CategoryDTO category)
        {
            await _categoryService.Add(category);
        }

        [HttpPut("/edit-category")]
        public async Task Edit(int id, [FromBody] CategoryDTO category)
        {
            await _categoryService.Edit(id,category);
        }

        [HttpDelete("/delete-category")]
        public async Task Delete(int id)
        {
            await _categoryService.Delete(id);
        }
    }
}