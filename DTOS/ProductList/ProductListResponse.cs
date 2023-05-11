using ShopSuphan.Models.OrderAggregate;
using ShopSuphan.Settings;

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
        public Models.OrderAggregate.OrderAccount OrderAccount { get; set; }
        static public ProductListResponse FromProductList(OrderItem productList)
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
                ImageProduct = !string.IsNullOrEmpty(productList.Product.Image) ? ServerURLcs.URLServer + "images/" + productList.Product.Image : "",

            };
        }
    }
}
