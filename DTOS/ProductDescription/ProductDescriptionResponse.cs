using ShopSuphan.Settings;

namespace ShopSuphan.DTOS.ProductDescription
{
    public class ProductDescriptionResponse
    {
        public string ID { get; set; }
        public string? Image { get; set; }
        public int? ProductID { get; set; }


        static public ProductDescriptionResponse FromDescription(Models.ProductDescription productDescription)
        {
            // return ตัวมันเอง
            return new ProductDescriptionResponse
            {
                ID = productDescription.ID,
                ProductID = productDescription.ProductID,
                Image = !string.IsNullOrEmpty(productDescription.Image) ? ServerURLcs.URLServer + "images/" + productDescription.Image : "",

            };
        }
    }
}
