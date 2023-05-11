using ShopSuphan.Models.OrderAggregate;

namespace ShopSuphan.DTOS.OrderAccount
{
    public class OrderPaymentRequest
    {
        public string? ID { get; set; }
        public IFormFileCollection? FormFiles { get; set; }
        public Paymentstatus PaymentStatus { get; set; }
    }
}
