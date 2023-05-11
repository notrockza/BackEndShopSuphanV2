using Microsoft.EntityFrameworkCore;
using ShopSuphan.interfaces;
using ShopSuphan.Models;

namespace ShopSuphan.Services
{
    public class ProductService : IProductService
    {
        private readonly DatabaseContext databaseContext;
        private readonly IUploadFileService uploadFileService;
        public ProductService(DatabaseContext databaseContext, IUploadFileService uploadFileService)
        {
            this.databaseContext = databaseContext;
            this.uploadFileService = uploadFileService;
        }
        public async Task Create(Product product)
        {
            await databaseContext.Product.AddAsync(product);
            await databaseContext.SaveChangesAsync();
        }

        public async Task Delete(Product product)
        {
            databaseContext.Remove(product);
            await databaseContext.SaveChangesAsync();
        }

        public async Task DeleteImage(string flieName)
        {
            await uploadFileService.DeleteImage(flieName);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await databaseContext.Product.Include(e => e.CategoryProduct).Include(e =>e.CommunityGroup).Include(e => e.LevelRarity).ToListAsync();
        }

        public async Task<Product> GetByID(int? idProduct)
        {
            return await databaseContext.Product.Include(e => e.CategoryProduct).Include(e => e.CommunityGroup).Include(e => e.LevelRarity).AsNoTracking().FirstOrDefaultAsync(x => x.ID == idProduct);
        }

        //public async Task<Product> GetByID(int id)
        //{
        //    return await databaseContext.Product.Include(e => e.CategoryProduct).AsNoTracking().FirstOrDefaultAsync(x => x.ID == id);
        //}

        public async Task Update(Product product)
        {
            databaseContext.Product.Update(product);
            await databaseContext.SaveChangesAsync();
        }

        public async Task<(string errorMessage, string imageName)> UploadImage(IFormFileCollection formFiles)
        {
            var errorMessage = string.Empty;
            var imageName = string.Empty;

            if (uploadFileService.IsUpload(formFiles))
            {
                errorMessage = uploadFileService.Validation(formFiles);

                //ถ้าเป็นnullหมายถึงจริง

                if (string.IsNullOrEmpty(errorMessage))
                {
                    //นั้คือการ upload เเบบเอาจริงเเล้ว
                    imageName = (await uploadFileService.UploadImages(formFiles))[0];

                }
            }
            return (errorMessage, imageName);
        }
    }
}
