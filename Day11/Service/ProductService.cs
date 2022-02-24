using Microsoft.EntityFrameworkCore;
using Day11.DTO;
using Day11.Models;
namespace Day11.Service
{
    public class ProductService : IProductService
    {
        private ProductStoreContext _dbContext;
        public ProductService(ProductStoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Product>> GetAllProduct()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task Add(ProductDTO product)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var item = await _dbContext.Products.AddAsync(new Product
                {
                    ProductName = product.ProductName,
                    Manufacture = product.Manufacture,
                    CategoryId = product.CategoryId,
                });

                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task Edit(int id ,ProductDTO product)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var categoryCheck = await _dbContext.Categories.FindAsync(product.CategoryId);
                if (categoryCheck != null)
                {
                    var item = await _dbContext.Products.FindAsync(id);
                    if (item != null)
                    {
                        item.ProductName = product.ProductName;
                        item.Manufacture = product.Manufacture;

                        await _dbContext.SaveChangesAsync();
                        await transaction.CommitAsync();
                    }
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
                var item = await _dbContext.Products.FindAsync(id);
                if (item != null)
                {
                    _dbContext.Products.Remove(item);
                    
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