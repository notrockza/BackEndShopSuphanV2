using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShopSuphan.Models
{
    public class AddressInformation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ID { get; set; }
        public string? Detail { get; set; }
        public string AccountName { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string AccountPhoneNumber { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string SubDistrict { get; set; }
        public string ZipCode { get; set; }
    }
}
