using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopSuphan.DTOS.CategoryProduct;
using ShopSuphan.interfaces;
using ShopSuphan.Models;

namespace ShopSuphan.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryProductController : ControllerBase
    {
        private readonly DatabaseContext databaseContext;
        private readonly ICategoryProductService categoryProductService;

        public CategoryProductController(DatabaseContext databaseContext, ICategoryProductService categoryProductService)
        {
            this.categoryProductService = categoryProductService;
            this.databaseContext = databaseContext;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await categoryProductService.GetAll());
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddCategoryProduct([FromForm] CategoryProductRequest categoryProductRequest)
        {

            var category = categoryProductRequest.Adapt<CategoryProduct>();
            await categoryProductService.Create(category);
            return Ok(new { msg = "OK", data = category });
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetCategoryByID(int id)
        {
            return Ok(await categoryProductService.GetByID(id));
        }

        [HttpDelete("[action]")]
        public async Task<ActionResult<CategoryProduct>> DeleteCategory([FromQuery] int id)
        {
            var result = await categoryProductService.GetByID(id);
            if (result == null) return Ok(new { msg = "ไม่พบประเภทสินค้า" });
            await categoryProductService.Delete(result);
            return Ok(new { msg = "OK", data = result });
        }

        [HttpPut("[action]")]
        public async Task<ActionResult<CategoryProduct>> UpdateCategory([FromForm] CategoryProductRequest categoryProductRequest)
        {
            var result = await categoryProductService.GetByID(categoryProductRequest.ID);
            if (result == null)
            {
                return Ok(new { msg = "ไม่พบสินค้า" });
            }

            categoryProductRequest.Adapt(result);
            await categoryProductService.Update(result);
            return Ok(new { msg = "OK", data = result });
        }
    }
}
