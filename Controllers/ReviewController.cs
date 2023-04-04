﻿using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopSuphan.DTOS.Account;
using ShopSuphan.DTOS.Review;
using ShopSuphan.interfaces;
using ShopSuphan.Models;

namespace ShopSuphan.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService reviewService;
        private readonly IReviewImageService reviewImageService;

        public ReviewController(IReviewService reviewService, IReviewImageService reviewImageService)
        {
            this.reviewService = reviewService;
            this.reviewImageService = reviewImageService;
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetReviewAll(int idProduct)
        {
            var result = (await reviewService.GetAll(idProduct)).Select(ReviewResponse.FromReview);
            if (result == null)
            {
                return Ok(new { msg = "ไม่พบข้อมูล" });
            }
            return Ok(new { msg = "OK", data = result });
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetReviewByIdProductList(string idProductList)
        {
            var result = await reviewService.GetByIdProductList(idProductList);
            if (result == null)
            {
                return Ok(new { msg = "ไม่พบข้อมูล" });
            }
            return Ok(new { msg = "OK", data = result });
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetReviewByIdCustomer(int idAccount, string idProductList)
        {
            var result = await reviewService.GetByIdAccount(idAccount, idProductList);
            if (result.Count() == 0)
            {
                return Ok(new { msg = "ไม่พบข้อมูล" });
            }
            return Ok(new { msg = "OK", data = result });
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddReview([FromForm] ReviewRequest reviewRequest)
        {
            #region จัดการรูปภาพ
            (string erorrImage, List<string> imageName) = await reviewService.UploadImage(reviewRequest.ImageFiles);
            //(string erorrVedio, string vedioName) = await reviewService.UploadVedio(reviewRequest.VedioFiles);
            if (!string.IsNullOrEmpty(erorrImage)) return BadRequest(erorrImage);
            #endregion
            var review = reviewRequest.Adapt<Review>();
            //review.Video = vedioName;
            var result = await reviewService.Create(review);
            await reviewImageService.Create(imageName, result.ID);
            return Ok(new { msg = "OK", data = review });
        }
    }
}
