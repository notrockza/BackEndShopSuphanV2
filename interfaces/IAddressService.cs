using ShopSuphan.Models;

namespace ShopSuphan.interfaces
{
    public interface IAddressService
    {
        Task<IEnumerable<Address>> GetAll(int idAccount);
        Task<Address> GetByID(string idAddress);
        Task<string> CreateAddressInformation(AddressInformation addressInformation);
        Task EditAddressStatus(Address address);
        Task CreateAddress(Address address);
        Task UpdateAddress(Address address);
        Task DeleteAddress(Address address);
    }
}
