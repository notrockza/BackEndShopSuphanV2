using Microsoft.EntityFrameworkCore;
using ShopSuphan.interfaces;
using ShopSuphan.Models;

namespace ShopSuphan.Services
{
    public class LevelRarityService : ILevelRarityService
    {
        private readonly DatabaseContext databaseContext;
        public LevelRarityService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task<IEnumerable<LevelRarity>> GetAll()
        {
            return await databaseContext.LevelRarity.ToListAsync();
        }
    }
}
