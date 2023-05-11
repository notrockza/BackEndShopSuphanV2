using Microsoft.EntityFrameworkCore;
using ShopSuphan.interfaces;
using ShopSuphan.Models;
using ShopSuphan.Models.OrderAggregate;

namespace ShopSuphan.Services
{
    public class ProductListService : IProductListService
    {
        private readonly DatabaseContext databaseContext;
        public ProductListService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task<IEnumerable<OrderItem>> GetAll(string idOrder)
        {
            return await databaseContext.OrderItem.Include(e => e.Product).Where(e => e.OrderAccountID == idOrder).ToListAsync();
        }

        public async Task<OrderItem> GetById(string id)
        {
            var result = await databaseContext.OrderItem.Include(e => e.Product).SingleOrDefaultAsync(e => e.ID == id);
            return result;
        }

        public async Task<List<OrderItem>> GetByIdProduct(int idProduct)
        {
            return await databaseContext.OrderItem.Where(e => e.ProductID == idProduct).ToListAsync();
        }

        public async Task<IEnumerable<OrderItem>> GetProductOrdered(string idOrder, string idAccount)
        {
            var data = await databaseContext.OrderItem.Include(e => e.Product).Where(e => e.OrderAccountID == idOrder).ToListAsync();
            for (var i = 0; i < data.Count(); i++)
            {

            }
            return null;
        }
    }
}
