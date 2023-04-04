namespace ShopSuphan.DTOS.Review
{
    public class ReviewResponse
    {
        public string ID { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public string Text { get; set; }
        public int AccountID { get; set; }
        public string ProductListID { get; set; }
        public Models.Account Account { get; set; }
        static public ReviewResponse FromReview(Models.Review review)
        {
            return new ReviewResponse
            {
                ID = review.ID,
                Text = review.Text,
                AccountID = review.AccountID,
                ProductListID = review.ProductListID,
                Created = review.Created,
                Account = review.Account,

            };
        }
    }
}
