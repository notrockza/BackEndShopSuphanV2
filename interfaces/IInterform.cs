using ShopSuphan.Models;

namespace ShopSuphan.interfaces
{
    public interface IInterform
    {
        Task<IEnumerable<Information>> GetAll();

        Task<Information> GetByID(int? information);
        Task Create(Information information);
        Task Update(Information information);
        Task Delete(Information information);
        Task<(string errorMessage, string imageName)> UploadImage(IFormFileCollection formFiles);
        Task DeleteImage(string flieName);
    }
}
