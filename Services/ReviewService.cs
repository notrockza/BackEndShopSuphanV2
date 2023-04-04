﻿using Microsoft.EntityFrameworkCore;
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
            var review = new List<Review>();
            var product = await productListService.GetByIdProduct(idProduct);
            if (product == null) return null;

            for (int i = 0; i < product.Count(); i++)
            {
                var data = await databaseContext.Reviews.Include(e => e.Account).Where(e => e.ProductListID == product[i].ID).ToListAsync();
                if (data == null) return null;
                review.AddRange(data);
            }

            return review;
        }

        public async Task<IEnumerable<Review>> GetByIdAccount(int idAccount, string idListProduct)
        {
            var review = await databaseContext.Reviews.Where(e => e.AccountID == idAccount && e.ProductListID == idListProduct).ToListAsync();
            return review;
        }

        public async Task<IEnumerable<Review>> GetByIdProductList(string idProductList)
        {
            var review = await databaseContext.Reviews.Where(e => e.ProductListID == idProductList).ToListAsync();
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
    }
}
