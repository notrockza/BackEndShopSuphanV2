using ShopSuphan.Models;

namespace ShopSuphan.interfaces
{
    public interface ICommunityGroupService
    {
        Task<IEnumerable<CommunityGroup>> GetAll();

        Task<CommunityGroup> GetByID(int id);
        Task Create(CommunityGroup communityGroup);
        Task Update(CommunityGroup communityGroup);
        Task Delete(CommunityGroup communityGroup);
    }
}
