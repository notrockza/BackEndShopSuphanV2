using ShopSuphan.interfaces;
using ShopSuphan.Models;

namespace ShopSuphan.Services
{
    public class AddressInformationService : IAddressInformationService
    {
        private readonly DatabaseContext databaseContext;
        public AddressInformationService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task<AddressInformation> GetById(string id)
        {
            var result = await databaseContext.AddressInformation.FindAsync(id);
            return result;
        }
    }
}
