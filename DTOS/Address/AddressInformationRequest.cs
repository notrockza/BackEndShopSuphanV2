using System.ComponentModel.DataAnnotations;

namespace ShopSuphan.DTOS.Address
{
    public class AddressInformationRequest
    {
        public string? ID { get; set; }
        public string? Detail { get; set; }
        [Required]
        public string AccountName { get; set; }
        [Required]
        public string AccountPhoneNumber { get; set; }
        [Required]
        public string Province { get; set; }
        [Required]
        public string District { get; set; }
        [Required]
        public string SubDistrict { get; set; }
        [Required]
        public string ZipCode { get; set; }
    }
}
