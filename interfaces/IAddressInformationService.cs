using ShopSuphan.Models;

namespace ShopSuphan.interfaces
{
    public interface IAddressInformationService
    {
        Task<AddressInformation> GetById(string id);
    }
}
