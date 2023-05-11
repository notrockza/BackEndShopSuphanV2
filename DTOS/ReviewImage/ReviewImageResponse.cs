using ShopSuphan.Settings;

namespace ShopSuphan.DTOS.ReviewImage
{
    public class ReviewImageResponse
    {
        public string ID { get; set; }
        public string Image { get; set; }
        static public ReviewImageResponse FromReviewImage(Models.ReviewImage reviewImage)
        {
            return new ReviewImageResponse
            {
                ID = reviewImage.ID,
                Image = !string.IsNullOrEmpty(reviewImage.Image) ? ServerURLcs.URLServer + "images/" + reviewImage.Image : "",

            };
        }
    }
}
