using Day11.DTO;
using Day11.Models;
namespace Day11.Service
{
    public interface ICategoryService
    {
        Task<List<Category>> GettAllCategory();
        Task Add(CategoryDTO category);
        Task Edit (int id, CategoryDTO category);
        Task Delete(int id);
    }
}