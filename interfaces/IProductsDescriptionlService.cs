using ShopSuphan.Models;

namespace ShopSuphan.interfaces
{
    public interface IProductsDescriptionlService
    {
        Task<IEnumerable<ProductDescription>> GetAll(int idProduct);
        Task<ProductDescription> GetByID(string ID);
        Task<(string errorMessage, List<string> imageName)> UploadImage(IFormFileCollection formFiles);
        Task Create(ProductDescription productDescription, List<string> imageName);
        Task DeleteImageID(ProductDescription productDescription);
        Task<ProductDescription> GetByIdDescription(string ID);
        Task DeleteImage(string fileName);
    }
}
