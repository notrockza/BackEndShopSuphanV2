namespace ShopSuphan.DTOS.Review
{
    public class ReviewRequest
    {
        public string ProductListID { get; set; }
        public string Text { get; set; }
        public int AccountID { get; set; }
        public IFormFileCollection? ImageFiles { get; set; }
    }
}
