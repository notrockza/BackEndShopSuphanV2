using ShopSuphan.Models;

namespace ShopSuphan.interfaces
{
    public interface IReviewImageService
    {
        Task<List<ReviewImage>> GetByIdReview(string idReview);
        Task Create(List<string> imageName, string ReviewID);
    }
}
