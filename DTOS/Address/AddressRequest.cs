using System.ComponentModel.DataAnnotations;

namespace ShopSuphan.DTOS.Address
{
    public class AddressRequest
    {
        [Required]
        public int AccountID { get; set; }
        public string? AddressInformationID { get; set; }
        public int? StatusAddressID { get; set; }
    }
}
