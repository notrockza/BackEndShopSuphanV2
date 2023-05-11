using ShopSuphan.DTOS.OrderAccount;
using ShopSuphan.DTOS.ProductList;
using ShopSuphan.Models.OrderAggregate;

namespace ShopSuphan.interfaces
{
    public interface IOrderAccountService
    {
        Task<IEnumerable<OrderDTO>> GetAll(int idAccount);
        Task<OrderAccount> GetByID(string id);
        Task AddOrder( ProductListOrderRequest productListOrderRequest);
        Task<IEnumerable<OrderItem>> GetAllProductList(string idOrder);
        Task UpdateOrder(OrderAccount orderAccount);
        Task<(string errorMessage, string imageName)> UploadImage(IFormFileCollection formFiles);
        Task DeleteImage(string fileName);
        Task ConfirmOrder(List<OrderAccount> orderAccounts);
        Task<IEnumerable<OrderDTO>> GetConfirm();

        Task<IEnumerable<OrderDTO>> GetConfirmOrderAccount(int idAccount);
        
    }
}
