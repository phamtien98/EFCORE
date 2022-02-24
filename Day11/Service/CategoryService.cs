using Microsoft.EntityFrameworkCore;
using Day11.DTO;
using Day11.Models;
namespace Day11.Service
{
    public class CategoryService : ICategoryService
    {
        private ProductStoreContext _dbContext;

        public CategoryService(ProductStoreContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Category>> GettAllCategory()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task Add(CategoryDTO category)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var item = await _dbContext.Categories.AddAsync(new Category
                {
                    CategoryName = category.CategoryName,
                });

                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task Edit(int id ,CategoryDTO category)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var item = await _dbContext.Categories.FindAsync(id);
                if (item != null)
                {
                    item.CategoryName = category.CategoryName;

                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task Delete(int id)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var item = await _dbContext.Categories.FindAsync(id);
                if (item != null)
                {
                    _dbContext.Categories.Remove(item);

                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
