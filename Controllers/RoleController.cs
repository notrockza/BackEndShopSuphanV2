    using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopSuphan.interfaces;

namespace ShopSuphan.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService roleService;

        public RoleController(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetRoleByID(int id)
        {
            return Ok(await roleService.GetRoleByID(id));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetRoleAll()
        {
            var result = await roleService.GetRoleAll();
          
            return Ok(new { data = result });
        }
    }
}
