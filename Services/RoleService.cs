using Microsoft.EntityFrameworkCore;
using ShopSuphan.interfaces;
using ShopSuphan.Models;

namespace ShopSuphan.Services
{
    public class RoleService : IRoleService
    {
        private readonly DatabaseContext databaseContext;

        public RoleService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<IEnumerable<Role>> GetRoleAll()
        {
            return await databaseContext.Role.ToListAsync();
        }

        public async Task<Role> GetRoleByID(int Id)
        {
            return await databaseContext.Role.FindAsync(Id);
        }
    }
}
