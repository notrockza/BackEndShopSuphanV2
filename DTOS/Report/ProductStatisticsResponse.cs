using ShopSuphan.DTOS.Products;
using ShopSuphan.Models;
using ShopSuphan.Settings;

namespace ShopSuphan.DTOS.Report
{
    public class ProductStatisticsResponse
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
        public Product Product { get; set; }
        public double? NumPercen { get; set; }
        public double? Amount { get; set; }

        static public ProductStatisticsResponse FromProductStatistics(ProductStatisticsDTO product)
        {
            // return ตัวมันเอง ProductStatisticsDTO
            return new ProductStatisticsResponse
            {
                ID = product.Product.ID,
                Name = product.Product.Name,
                Image = !string.IsNullOrEmpty(product.Product.Image) ? ServerURLcs.URLServer + "images/" + product.Product.Image : "",
                Stock = product.Product.Stock, 
                Price = product.Product.Price, 
                Detail = product.Product.Detail,
                CategoryName = product.Product.CategoryProduct.Name,
                CommunityGroupName = product.Product.CommunityGroup.CommunityGroupName, 
                LevelRarityName = product.Product.LevelRarity.LevelRarityName,
                Amount = product.Amount,
                NumPercen = product.NumPercen,
               
            };

        }

        internal static object FromProductStatistics(SalesStatisticsDTO result)
        {
            throw new NotImplementedException();
        }
    }
}


//{
//    "msg": "OK",
//  "data": [
//    {
//        "product": {
//            "id": 5,
//        "name": "test03",
//        "price": 111,
//        "stock": 47,
//        "detail": "test",
//        "image": "02419195-aadc-4e10-abcc-f468c5b00364.png",
//        "categoryProductID": 2,
//        "categoryProduct": null,
//        "communityGroupID": 1,
//        "communityGroup": null,
//        "levelRarityID": 1,
//        "levelRarity": null
//        },
//      "numPercen": 100,
//      "amount": 3
//    }
//  ]
//}