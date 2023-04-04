using ShopSuphan.Models;

namespace ShopSuphan.interfaces
{
    public interface IReviewService
    {
        Task<IEnumerable<Review>> GetAll(int idProduct);
        Task<IEnumerable<Review>> GetByIdAccount(int idAccount, string idListProduct);
        Task<Review> Create(Review review);
        Task<IEnumerable<Review>> GetByIdProductList(string idProductList);
        Task<(string erorrImage, List<string> imageName)> UploadImage(IFormFileCollection formFiles);
        Task<(string erorrVedio, string vedioName)> UploadVedio(IFormFileCollection formFiles);
        Task DeleteImage(string fileName);
    }
}
