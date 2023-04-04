using ShopSuphan.Models;

namespace ShopSuphan.DTOS.Products
{
    public class ProductResponse
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }

        public string Detail { get; set; }
        public string CategoryName { get; set; }

        public string CommunityGroupName { get; set; }

        public string LevelRarityName { get; set; }
        // Models.Product product ส่งตัวจริงเข้ามาก่อน
        static public ProductResponse FromProduct(Product product)
        {
            // return ตัวมันเอง
            return new ProductResponse
            {
                ID = product.ID,
                Name = product.Name,
                Image = !string.IsNullOrEmpty(product.Image) ? "https://localhost:7048/" + "images/" + product.Image : "",
                Stock = product.Stock,
                Price = product.Price,
                Detail = product.Detail,
                CategoryName = product.CategoryProduct.Name,
                CommunityGroupName = product.CommunityGroup.CommunityGroupName,
                LevelRarityName = product.LevelRarity.LevelRarityName

            };

        }
    }
}
