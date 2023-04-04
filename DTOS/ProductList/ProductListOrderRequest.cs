namespace ShopSuphan.DTOS.ProductList
{
    public class ProductListOrderRequest
    {
        public string[] CartID { get; set; }
        public string? OrderAccountID { get; set; }
        public int[] ProductID { get; set; }
        public int[] ProductPrice { get; set; }
        public int[] ProductAmount { get; set; }
    }
}
