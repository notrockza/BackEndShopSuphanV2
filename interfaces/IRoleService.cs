using ShopSuphan.Models;

namespace ShopSuphan.interfaces
{
    public interface IRoleService
    {
        Task<Role> GetRoleByID(int Id);

        Task<IEnumerable<Role>> GetRoleAll();

    }
}
