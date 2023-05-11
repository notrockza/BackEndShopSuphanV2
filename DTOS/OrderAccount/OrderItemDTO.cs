namespace ShopSuphan.DTOS.OrderAccount
{
    public class OrderItemDTO
    {
        public string CartID { get; set; }
        public int ProductID { get; set; }
        public int ProductPrice { get; set; }
        public int ProductAmount { get; set; }
    }
}
