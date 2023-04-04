using Microsoft.EntityFrameworkCore;
using ShopSuphan.interfaces;
using ShopSuphan.Models;

namespace ShopSuphan.Services
{
    public class CommunityGroupService : ICommunityGroupService
    {
        private readonly DatabaseContext databaseContext;
        public CommunityGroupService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task Create(CommunityGroup communityGroup)
        {
            await databaseContext.CommunityGroup.AddAsync(communityGroup);
            await databaseContext.SaveChangesAsync();
        }

        public async Task Delete(CommunityGroup communityGroup)
        {
            databaseContext.Remove(communityGroup);
            await databaseContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<CommunityGroup>> GetAll()
        {
            return await databaseContext.CommunityGroup.ToListAsync();
        }

        public async Task<CommunityGroup> GetByID(int id)
        {
            return await databaseContext.CommunityGroup.FindAsync(id);
        }

        public async Task Update(CommunityGroup communityGroup)
        {
            databaseContext.CommunityGroup.Update(communityGroup);
            await databaseContext.SaveChangesAsync();
        }
    }
}
