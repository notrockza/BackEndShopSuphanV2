using System.ComponentModel.DataAnnotations;

namespace ShopSuphan.DTOS.Address
{
    public class AddressRequest2
    {
        public string ID { get; set; }
        [Required]
        public int AccountID { get; set; }
        public string? AddressInformationID { get; set; }
        public int? StatusAddressID { get; set; }
    }
}
