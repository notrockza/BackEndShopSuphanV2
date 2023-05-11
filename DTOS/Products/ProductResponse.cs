using ShopSuphan.Models;
using ShopSuphan.Settings;

namespace ShopSuphan.DTOS.Products
{
    public class ProductResponse
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }

        public string Detail { get; set; }
        public string CategoryName { get; set; }

        public string CommunityGroupName { get; set; }

        public string LevelRarityName { get; set; }

        public int CategoryProductID { get; set; }

        public int CommunityGroupID { get; set; }

        public int LevelRarityID { get; set; }
        public string TextHistory { get; set; }
        // Models.Product product ส่งตัวจริงเข้ามาก่อน
        static public ProductResponse FromProduct(Product product)
        {
            // return ตัวมันเอง
            return new ProductResponse
            {
                ID = product.ID,
                Name = product.Name,
                Image = !string.IsNullOrEmpty(product.Image) ? ServerURLcs.URLServer + "images/" + product.Image : "",
                Stock = product.Stock,
                Price = product.Price,
                Detail = product.Detail,
                CategoryName = product.CategoryProduct.Name,
                CommunityGroupName = product.CommunityGroup.CommunityGroupName,
                LevelRarityName = product.LevelRarity.LevelRarityName,
                CategoryProductID = product.CategoryProductID,
                CommunityGroupID = product.CommunityGroupID,
                LevelRarityID = product.LevelRarityID,
                TextHistory = product.CommunityGroup.TextHistory,

            };

        }
    }
}
