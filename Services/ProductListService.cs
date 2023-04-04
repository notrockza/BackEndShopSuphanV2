using Microsoft.EntityFrameworkCore;
using ShopSuphan.interfaces;
using ShopSuphan.Models;

namespace ShopSuphan.Services
{
    public class ProductListService : IProductListService
    {
        private readonly DatabaseContext databaseContext;
        public ProductListService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task<IEnumerable<ProductList>> GetAll(string idOrder)
        {
            return await databaseContext.ProductList.Include(e => e.Product).Where(e => e.OrderAccountID == idOrder).ToListAsync();
        }

        public async Task<ProductList> GetById(string id)
        {
            var result = await databaseContext.ProductList.Include(e => e.Product).SingleOrDefaultAsync(e => e.ID == id);
            return result;
        }

        public async Task<List<ProductList>> GetByIdProduct(int idProduct)
        {
            return await databaseContext.ProductList.Where(e => e.ProductID == idProduct).ToListAsync();
        }

        public async Task<IEnumerable<ProductList>> GetProductOrdered(string idOrder, string idAccount)
        {
            var data = await databaseContext.ProductList.Include(e => e.Product).Where(e => e.OrderAccountID == idOrder).ToListAsync();
            for (var i = 0; i < data.Count(); i++)
            {

            }
            return null;
        }
    }
}
