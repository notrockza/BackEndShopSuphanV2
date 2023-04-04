using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopSuphan.DTOS.CommunityGroup;
using ShopSuphan.interfaces;
using ShopSuphan.Models;

namespace ShopSuphan.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CommunityGroupController : ControllerBase
    {
        private readonly ICommunityGroupService CommunityGroupService;
        public CommunityGroupController(ICommunityGroupService CommunityGroupService)
        {
            this.CommunityGroupService = CommunityGroupService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await CommunityGroupService.GetAll());
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddCommunityGroup([FromForm] CommunityGroupRequest communityGroupRequest)
        {

            var category = communityGroupRequest.Adapt<CommunityGroup>();
            await CommunityGroupService.Create(category);
            return Ok(new { msg = "OK", data = category });
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetCommunityGroupByID(int id)
        {
            return Ok(await CommunityGroupService.GetByID(id));
        }

        [HttpDelete("[action]")]
        public async Task<ActionResult<CategoryProduct>> DeleteCommunityGroup([FromQuery] int id)
        {
            var result = await CommunityGroupService.GetByID(id);
            if (result == null) return Ok(new { msg = "ไม่พบชุมชน" });
            await CommunityGroupService.Delete(result);
            return Ok(new { msg = "OK", data = result });
        }

        [HttpPut("[action]")]
        public async Task<ActionResult<CategoryProduct>> UpdateCommunityGroup([FromForm] CommunityGroupRequest communityGroupRequest)
        {
            var result = await CommunityGroupService.GetByID(communityGroupRequest.ID);
            if (result == null)
            {
                return Ok(new { msg = "ไม่พบสินค้า" });
            }

            communityGroupRequest.Adapt(result);
            await CommunityGroupService.Update(result);
            return Ok(new { msg = "OK", data = result });
        }
    }
}
