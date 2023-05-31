

using Mapster;
using Microsoft.AspNetCore.Mvc;
using ShopSuphan.DTOS.Information;
using ShopSuphan.DTOS.Products;
using ShopSuphan.interfaces;
using ShopSuphan.Models;
using ShopSuphan.Services;

namespace ShopSuphan.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InformationController : ControllerBase
    {
        private readonly DatabaseContext databaseContext;
        private readonly IInterform informationSerices;

        public InformationController(DatabaseContext databaseContext, IInterform informationSerices)
        {
            this.databaseContext = databaseContext;
            this.informationSerices = informationSerices;
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetInformation()
        {
            var result = (await informationSerices.GetAll()).Select(InformationResponse.FromInformation);
            return Ok(new { msg = "OK", data = result });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInformationByID(int id)
        {
            var result = await informationSerices.GetByID(id);
            if (result == null) return Ok(new { msg = "ไม่พบข้อมูล" });
            return Ok(new { msg = "OK", data = result });
        }


        [HttpPost("[action]")]
        public async Task<ActionResult<Information>> AddInformation([FromForm] InformationRequest informationRequest)
        {
            (string errorMesage, string imageName) = await informationSerices.UploadImage(informationRequest.FormFiles);
            var result = await informationSerices.GetByID(informationRequest.ID);
            if (result != null)
            {
                return Ok(new { msg = "รหัสซ้ำ" });
            }

            var information = informationRequest.Adapt<Information>();
            information.Image = imageName;
            await informationSerices.Create(information);
            return Ok(new { msg = "OK", data = information });
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<Information>> UpdateInformation([FromForm] InformationRequest informationRequest)
        {
            var result = await informationSerices.GetByID(informationRequest.ID);
            if (result == null)
            {
                return Ok(new { msg = "ไม่พบข้อมูล" });
            }
            #region จัดการรูปภาพ
            (string errorMesage, string imageName) = await informationSerices.UploadImage(informationRequest.FormFiles);
            if (!string.IsNullOrEmpty(errorMesage)) return BadRequest(errorMesage);

            if (!string.IsNullOrEmpty(imageName))
            {
                await informationSerices.DeleteImage(result.Image);
                result.Image = imageName;
            }
            #endregion
            var information = informationRequest.Adapt<Information>();
            information.Image = imageName;
            if (string.IsNullOrEmpty(imageName))
            {
                information.Image = result.Image;
            }
            await informationSerices.Update(information);
            return Ok(new { msg = "OK", data = information });
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<Information>> DeleteInformation([FromQuery] int id)
        {
            var result = await informationSerices.GetByID(id);
            if (result == null) return Ok(new { msg = "ไม่พบข้อมูล" });
            await informationSerices.Delete(result);
            await informationSerices.DeleteImage(result.Image);
            return Ok(new { msg = "OK", data = result });
        }

    }
}
