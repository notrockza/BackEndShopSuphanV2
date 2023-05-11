using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopSuphan.Models.OrderAggregate
{
    public class OrderAccount
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ID { get; set; }
        public Paymentstatus PaymentStatus { get; set; } = Paymentstatus.WaitingForPayment;
        public string? ProofOfPayment { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public int PriceTotal { get; set; }
        public int DeliveryFee { get; set; } // ค่าจัดส่ง
        public bool AccountStatus { get; set; }
        public string AddressID { get; set; }
        [ForeignKey("AddressID")] 
        //[ValidateNever]
        public virtual Address Address { get; set; }

    }
}
