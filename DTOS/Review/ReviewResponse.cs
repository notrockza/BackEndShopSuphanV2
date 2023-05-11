using ShopSuphan.DTOS.Account;
using ShopSuphan.DTOS.OrderAccount;
using ShopSuphan.Models;
using static System.Net.Mime.MediaTypeNames;

namespace ShopSuphan.DTOS.Review
{
    public class ReviewResponse
    {
        public string ID { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public string Text { get; set; }
        public int AccountID { get; set; }
        public Models.Product Product { get; set; }
        public Models.Account Account { get; set; }
        static public ReviewResponse FromReview(Models.Review review)
        {
            return new ReviewResponse
            {
                ID = review.ID,
                Text = review.Text,
                AccountID = review.AccountID,
                Product = review.Product,
                Created = review.Created,
                Account = review.Account,
                //Account = db.Account.Where(e => e.ID == review.AccountID).Select(item => new ReviewDTO
                //{
                    
                //    ID = item.ID,
                //    Image= item.Image,
                //    Email= item.Email,
                //    Tell = item.Tell,
                //    Name = item.Name,
                //    Password= item.Password,
                    



                //}).ToList()

            };
        }


            //static public testResponse Fromtest(Models.Account account)
            //{
            //    return new testResponse
            //    {
            //        ID = account.ID,
            //        Name = account.Name,
            //        Image = !string.IsNullOrEmpty(account.Image) ? "https://localhost:7048/" + "images/" + account.Image : "",
            //        Email = account.Email,
            //        Tell = account.Tell,
            //        Password = account.Password,
            //        RoleName = account.Role.Name

            //    };
            //}




    }
}
