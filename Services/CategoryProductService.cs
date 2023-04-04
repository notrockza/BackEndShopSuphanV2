using Microsoft.EntityFrameworkCore;
using ShopSuphan.interfaces;
using ShopSuphan.Models;

namespace ShopSuphan.Services
{
    public class CategoryProductService : ICategoryProductService
    {
        private readonly DatabaseContext databaseContext;
        public CategoryProductService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task Create(CategoryProduct categoryProduct)
        {
            await databaseContext.CategoryProduct.AddAsync(categoryProduct);
            await databaseContext.SaveChangesAsync();
        }

        public async Task Delete(CategoryProduct categoryProduct)
        {
            databaseContext.Remove(categoryProduct);
            await databaseContext.SaveChangesAsync();
        }

        public async
            Task<IEnumerable<CategoryProduct>> GetAll()
        {
            return await databaseContext.CategoryProduct.ToListAsync();
        }

        public async Task<CategoryProduct> GetByID(int id)
        {
            return await databaseContext.CategoryProduct.FindAsync(id);
        }

        public async Task Update(CategoryProduct categoryProduct)
        {
            databaseContext.CategoryProduct.Update(categoryProduct);
            await databaseContext.SaveChangesAsync();
        }


    }
}
