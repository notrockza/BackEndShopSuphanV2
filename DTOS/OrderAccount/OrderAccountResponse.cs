using ShopSuphan.Settings;

namespace ShopSuphan.DTOS.OrderAccount
{
    public class OrderAccountResponse
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
     
        static public OrderAccountResponse FromOrder(Models.OrderAggregate.OrderAccount orderAccount)
        {
            // return ตัวมันเอง
            return new OrderAccountResponse
            {
                ID = orderAccount.ID,
                //PaymentStatus = orderAccount.PaymentStatus,
               // ProofOfPayment = orderAccount.ProofOfPayment,
                ProofOfPayment = !string.IsNullOrEmpty(orderAccount.ProofOfPayment) ? ServerURLcs.URLServer + "images/" + orderAccount.ProofOfPayment : "",
                PriceTotal = orderAccount.PriceTotal,
                DeliveryFee = orderAccount.DeliveryFee,
                AccountStatus = orderAccount.AccountStatus,
                AddressID = orderAccount.AddressID,
                Address = orderAccount.Address,

            };
        }
    }
}
