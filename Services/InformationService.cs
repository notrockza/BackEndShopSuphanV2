using Microsoft.EntityFrameworkCore;
using ShopSuphan.interfaces;
using ShopSuphan.Models;

namespace ShopSuphan.Services
{
    public class InformationService : IInterform
    {
        private readonly DatabaseContext databaseContext;
        private readonly IUploadFileService uploadFileService;

        public InformationService(DatabaseContext databaseContext, IUploadFileService uploadFileService) {
            this.databaseContext = databaseContext;
            this.uploadFileService = uploadFileService;
        }

        public async Task Create(Information information)
        {
            await databaseContext.Informations.AddAsync(information);
            await databaseContext.SaveChangesAsync();
        }

        public async Task Delete(Information information)
        {
            databaseContext.Remove(information);
            await databaseContext.SaveChangesAsync();
        }

        public async Task DeleteImage(string flieName)
        {
            await uploadFileService.DeleteImage(flieName);
        }

        public async Task<IEnumerable<Information>> GetAll()
        {
            var show = await databaseContext.Informations.ToListAsync();
            return show;
        }

        public async Task<Information> GetByID(int? information)
        {
            return await databaseContext.Informations.AsNoTracking().FirstOrDefaultAsync(x => x.ID == information);
        }

        public async Task Update(Information information)
        {
            databaseContext.Informations.Update(information);
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
