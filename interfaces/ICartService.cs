using ShopSuphan.Models;

namespace ShopSuphan.interfaces
{
    public interface ICartService
    {
        Task<IEnumerable<Cart>> GetAll(int idAccount);
        Task<Cart> GetByID(string ID);
        Task Create(Cart cart);
        Task Update(Cart cart);
        Task Delete(Cart cart);
    }
}
