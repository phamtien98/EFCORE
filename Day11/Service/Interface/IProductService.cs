using Day11.DTO;
using Day11.Models;
namespace Day11.Service
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProduct();
        Task Add(ProductDTO product);
        Task Edit (int id, ProductDTO product);
        Task Delete(int id);
    }
}