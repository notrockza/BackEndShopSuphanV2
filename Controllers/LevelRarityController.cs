using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopSuphan.interfaces;
using ShopSuphan.Services;

namespace ShopSuphan.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LevelRarityController : ControllerBase
    {
        private readonly ILevelRarityService LevelRarityService;
        public LevelRarityController(ILevelRarityService LevelRarityService)
        {
            this.LevelRarityService = LevelRarityService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await LevelRarityService.GetAll());
        }

    }
}
