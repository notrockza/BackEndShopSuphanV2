using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;

namespace ShopSuphan.Models
{
    public class Address
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ID { get; set; }
        public int AccountID { get; set; }
        public int StatusAddressID { get; set; }

        public string AddressInformationID { get; set; }
        [ForeignKey("AddressInformationID")]
        //[ValidateNever]
        public virtual AddressInformation AddressInformation { get; set; }
        [ForeignKey("AccountID")]
        //[ValidateNever]
        public virtual Account Account { get; set; }
        [ForeignKey("StatusAddressID")]
        public virtual StatusAddress StatusAddress { get; set; }
    }
}

