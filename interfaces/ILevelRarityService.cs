using ShopSuphan.Models;

namespace ShopSuphan.interfaces
{
    public interface ILevelRarityService
    {
        Task<IEnumerable<LevelRarity>> GetAll();
    }
}
