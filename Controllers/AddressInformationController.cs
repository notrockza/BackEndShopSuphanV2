using Microsoft.AspNetCore.Mvc;
using ShopSuphan.interfaces;
using ShopSuphan.Services;

namespace ShopSuphan.Controllers
{
    public class AddressInformationController : Controller
    {
        private readonly IAddressInformationService addressInformationService;
        public AddressInformationController(IAddressInformationService addressInformationService)
        {
            this.addressInformationService = addressInformationService;
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetAddressInformationById(string id)
        {
            var result = await addressInformationService.GetById(id);
            return Ok(result);
        }
    }
}
