using ShopSuphan.Models.OrderAggregate;

namespace ShopSuphan.interfaces
{
    public interface IProductListService
    {
        Task<IEnumerable<OrderItem>> GetAll(string idOrder);
        Task<List<OrderItem>> GetByIdProduct(int idProduct);
        Task<OrderItem> GetById(string id);
        // ดึงสินค้าที่ต้องชำระเงินอยู่ในส่วน Seller
        Task<IEnumerable<OrderItem>> GetProductOrdered(string idOrder, string idAccount);
    }
}
