using Microsoft.EntityFrameworkCore;
using ShopSuphan.interfaces;
using ShopSuphan.Models;

namespace ShopSuphan.Services
{
    public class ReviewService : IReviewService
    {
        private readonly DatabaseContext databaseContext;
        private readonly IProductListService productListService;
        private readonly IUploadFileService uploadFileService;

        public ReviewService(DatabaseContext databaseContext, IProductListService productListService, IUploadFileService uploadFileService)
        {
            this.databaseContext = databaseContext;
            this.productListService = productListService;
            this.uploadFileService = uploadFileService;
        }
        public async Task<Review> Create(Review review)
        {
            if (string.IsNullOrEmpty(review.ID)) review.ID = await GenerateID();
            await databaseContext.Reviews.AddAsync(review);
            await databaseContext.SaveChangesAsync();
            return review;
        }

        public async Task DeleteImage(string fileName)
        {
            await uploadFileService.DeleteImage(fileName);
        }

        public async Task<IEnumerable<Review>> GetAll(int idProduct)
        {

            var review = await databaseContext.Reviews.Include(e => e.Account).Where(e => e.ProductID == idProduct).ToListAsync();
            if (review == null) return null;
            return review;
        }


        public async Task<(string erorrImage, List<string> imageName)> UploadImage(IFormFileCollection formFiles)
        {
            var erorrImage = string.Empty;
            //var imageName = new List<string>();
            var imageName = new List<string>();
            if (uploadFileService.IsUpload(formFiles))
            {
                erorrImage = uploadFileService.Validation(formFiles);
                if (string.IsNullOrEmpty(erorrImage))
                {
                    imageName = (await uploadFileService.UploadImages(formFiles));
                }
            }
            return (erorrImage, imageName);
        }

        public Task<(string erorrVedio, string vedioName)> UploadVedio(IFormFileCollection formFiles)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GenerateID()
        {
            Random randomNumber = new Random();
            string Id = "";
            // while คือ roobที่ไมมีที่สิ้นสุดจนกว่าเราจะสั่งให้หยุด
            while (true)
            {
                int num = randomNumber.Next(1000000);

                Id = DateTime.Now.ToString("yyyy-MM-ddTHH-mm-ss") + "-" + num;

                var result = await databaseContext.Reviews.FindAsync(Id);

                if (result == null)
                {
                    break;
                };
            }
            return Id;
        }

        public async Task<IEnumerable<Review>> GetByIdListProduct(int idAccount, int idProduct)
        {

            var review = await databaseContext.Reviews.Include(e => e.Account).Include(e => e.Product).Where(e => e.AccountID == idAccount).Where(e => e.ProductID == idProduct).ToListAsync();
            if (review == null) return null;
            return review;


        }

        
    }
}
