namespace ShopSuphan.DTOS.Address
{
    public class AddressResponse
    {
        public string ID { get; set; }
        public Models.AddressInformation AddressInformation { get; set; }
        public Models.Account Account { get; set; }
        public Models.StatusAddress StatusAddress { get; set; }
        public int StatusAddressID { get; set; }
        static public AddressResponse FromAddress(Models.Address address)
        {
            // return ตัวมันเอง
            return new AddressResponse
            {
                ID = address.ID,
                AddressInformation = address.AddressInformation,
                Account = address.Account,
                StatusAddress = address.StatusAddress,
                StatusAddressID = address.StatusAddressID,
            };
        }
    }
}
