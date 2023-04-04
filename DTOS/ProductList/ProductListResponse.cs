namespace ShopSuphan.DTOS.ProductList
{
    public class ProductListResponse
    {
        public string ID { get; set; }
        public string OrderAccountID { get; set; }
        public int ProductID { get; set; }
        public int ProductPrice { get; set; }
        public int ProductAmount { get; set; }
        public string ImageProduct { get; set; }
        public Models.Product Product { get; set; }
        public Models.OrderAccount OrderAccount { get; set; }
        static public ProductListResponse FromProductList(Models.ProductList productList)
        {
            // return ตัวมันเอง
            return new ProductListResponse
            {
                ID = productList.ID,
                OrderAccountID = productList.OrderAccountID,
                ProductID = productList.ProductID,
                ProductPrice = productList.ProductPrice,
                ProductAmount = productList.ProductAmount,
                Product = productList.Product,
                OrderAccount = productList.OrderAccount,
                ImageProduct = !string.IsNullOrEmpty(productList.Product.Image) ? "https://localhost:7048/" + "images/" + productList.Product.Image : "",

            };
        }
    }
}
