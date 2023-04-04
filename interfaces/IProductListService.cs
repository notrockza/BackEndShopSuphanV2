using ShopSuphan.Models;

namespace ShopSuphan.interfaces
{
    public interface IProductListService
    {
        Task<IEnumerable<ProductList>> GetAll(string idOrder);
        Task<List<ProductList>> GetByIdProduct(int idProduct);
        Task<ProductList> GetById(string id);
        // ดึงสินค้าที่ต้องชำระเงินอยู่ในส่วน Seller
        Task<IEnumerable<ProductList>> GetProductOrdered(string idOrder, string idAccount);
    }
}
