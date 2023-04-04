using ShopSuphan.Models;

namespace ShopSuphan.interfaces
{
    public interface ICategoryProductService
    {
        Task<IEnumerable<CategoryProduct>> GetAll();
        Task<CategoryProduct> GetByID(int id);
        Task Create(CategoryProduct categoryProduct);
        Task Update(CategoryProduct categoryProduct);
        Task Delete(CategoryProduct categoryProduct);
    }
}
