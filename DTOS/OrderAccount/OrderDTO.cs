using ShopSuphan.Models.OrderAggregate;

namespace ShopSuphan.DTOS.OrderAccount
{
    public class OrderDTO
    {
        public string ID { get; set; }
        public Paymentstatus PaymentStatus { get; set; }
        public string? ProofOfPayment { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public int PriceTotal { get; set; }
        public int DeliveryFee { get; set; }
        public bool AccountStatus { get; set; }
        public string AddressID { get; set; }
        public Models.Address Address { get; set; }
        public List<OrderItemV2DTO> OrderItems { get; set; }
    }
}
