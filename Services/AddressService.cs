using Microsoft.EntityFrameworkCore;
using ShopSuphan.interfaces;
using ShopSuphan.Models;

namespace ShopSuphan.Services
{
    public class AddressService : IAddressService
    {
        private readonly DatabaseContext databaseContext;

        public AddressService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task CreateAddress(Address address)
        {
            if (string.IsNullOrEmpty(address.ID))
            {
                address.ID = GenerateIDAddress();
            }
            if (address.StatusAddressID == 0)
            {
                var addressStatus = databaseContext.Address.Where(x => x.AccountID == address.AccountID).FirstOrDefault();
                if (addressStatus == null)
                {
                    address.StatusAddressID = 1;
                }
                else
                {
                    address.StatusAddressID = 2;
                }
            }

            await databaseContext.Address.AddAsync(address);
            await databaseContext.SaveChangesAsync();
        }

        public async Task<string> CreateAddressInformation(AddressInformation addressInformation)
        {
            if (string.IsNullOrEmpty(addressInformation.ID))
            {
                addressInformation.ID = await GenerateIDAddressInformation();
            }
            await databaseContext.AddressInformation.AddAsync(addressInformation);
            await databaseContext.SaveChangesAsync();
            return addressInformation.ID;
        }

        public async Task EditAddressStatus(Address address)
        {
            var result = await databaseContext.Address.Where(e => e.AccountID == address.AccountID && e.ID != address.ID).ToListAsync();
            if (result != null)
            {
                for (int i = 0; i < result.Count; i++)
                {
                    result[i].StatusAddressID = 2;

                }

            }

            databaseContext.UpdateRange(result);
            databaseContext.Update(address);
            await databaseContext.SaveChangesAsync();
        }
    

        public async Task<IEnumerable<Address>> GetAll(int idAccount)
        {
            return await databaseContext.Address.Include(e => e.AddressInformation).Include(e => e.StatusAddress).Include(e => e.Account).Where(e => e.AccountID == idAccount).ToListAsync();
        }

        public async Task<Address> GetByID(string idAddress)
        {
            return await databaseContext.Address.Include(e => e.AddressInformation).AsNoTracking().FirstOrDefaultAsync(x => x.ID == idAddress);
        }

        public string GenerateIDAddress()
        {
            var result = databaseContext.Address.OrderByDescending(a => a.ID).FirstOrDefault();
            if (result != null)
            {
                int ID = Convert.ToInt32(result.ID);
                return (ID + 1).ToString();
            }
            return "1";
        }

        public async Task<string> GenerateIDAddressInformation()
        {
            Random randomNumber = new Random();
            string IdProductListr = "";
            // while คือ roobที่ไมมีที่สิ้นสุดจนกว่าเราจะสั่งให้หยุด
            while (true)
            {
                int num = randomNumber.Next(1000000);

                IdProductListr = DateTime.Now.ToString("yyyy-MM-ddTHH-mm-ss") + "-" + num;

                var result = await databaseContext.AddressInformation.SingleOrDefaultAsync(x => x.ID == IdProductListr);

                if (result == null)
                {
                    break;
                };
            }
            return IdProductListr;
        }

        public async Task UpdateAddress(Address address)
        {
            databaseContext.UpdateRange(address);
            databaseContext.Address.Update(address);
            await databaseContext.SaveChangesAsync();
        }

        public async Task DeleteAddress(Address address)
        {
            databaseContext.Remove(address);
            databaseContext.Remove(address.AddressInformation);
            await databaseContext.SaveChangesAsync();
        }

    }
}
