using Day11.DTO;
using Microsoft.AspNetCore.Mvc;
using Day11.Service;
using Day11.Models;
namespace Day11.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("/get-all-product")]
        public async Task<List<Product>> GetAllProduct()
        {
            return await _productService.GetAllProduct();
        }

        [HttpPost("/add-product")]
        public async Task Add([FromBody] ProductDTO product)
        {
             await _productService.Add(product);
        }

        [HttpPut("/edit-product")]
        public async Task Edit(int id, [FromBody] ProductDTO product)
        {
             await _productService.Edit(id,product);
        }

        [HttpDelete("/delete-product")]
        public async Task Delete(int id)
        {
            await _productService.Delete(id);
        }
    }
}