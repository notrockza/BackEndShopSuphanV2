using ShopSuphan.DTOS.ProductList;
using ShopSuphan.Models;

namespace ShopSuphan.interfaces
{
    public interface IOrderAccountService
    {
        Task<IEnumerable<OrderAccount>> GetAll(int idAccount);
        Task<OrderAccount> GetByID(string id);
        Task AddOrder(OrderAccount orderAccount, ProductListOrderRequest productListOrderRequest);
        Task<IEnumerable<ProductList>> GetAllProductList(string idOrder);
        Task UpdateOrder(OrderAccount orderAccount);
        Task<(string errorMessage, string imageName)> UploadImage(IFormFileCollection formFiles);
        Task DeleteImage(string fileName);
        Task ConfirmOrder(List<OrderAccount> orderAccounts);
        Task<IEnumerable<OrderAccount>> GetConfirm();
    }
}
