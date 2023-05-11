using ShopSuphan.DTOS.OrderAccount;

namespace ShopSuphan.DTOS.ProductList
{
    public class ProductListOrderRequest
    {
        public string AddrrssID { get; set; }
        public List<OrderItemDTO> Items { get; set; }
    }
}
