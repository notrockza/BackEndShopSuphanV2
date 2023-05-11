namespace ShopSuphan.DTOS.OrderAccount
{
    public class OrderAccountRequest
    {
        public string ID { get; set; }
        public bool PaymentStatus { get; set; }
        public string? ProofOfPayment { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public int PriceTotal { get; set; }
        public int DeliveryFee { get; set; }
        public bool AccountStatus { get; set; }
        public string AddressID { get; set; }
        public Models.Address Address { get; set; }
    }
}
