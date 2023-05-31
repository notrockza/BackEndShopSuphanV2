using Mapster;
using Microsoft.AspNetCore.Mvc;
using ShopSuphan.DTOS.Address;
using ShopSuphan.DTOS.Products;
using ShopSuphan.interfaces;
using ShopSuphan.Models;
using ShopSuphan.Services;
using System.Net;

namespace ShopSuphan.Controllers
{
    public class AddressController : Controller
    {
        private readonly IAddressService addressService;

        public AddressController(IAddressService addressService)
        {
            this.addressService = addressService;
        }

        [HttpGet("[action]/{idAccount}")]
        public async Task<IActionResult> GetAddressAll(int idAccount)
        {
            var result = (await addressService.GetAll(idAccount)).Select(AddressResponse.FromAddress);

            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateAddress([FromForm] AddressInformationRequest addressInformationRequest, [FromForm] AddressRequest address)
        {
            var addressInformation = addressInformationRequest.Adapt<AddressInformation>();
            var resultAddressInformationID = await addressService.CreateAddressInformation(addressInformation);
            var addresses = address.Adapt<Address>();
            addresses.AddressInformationID = resultAddressInformationID;
            await addressService.CreateAddress(addresses);
            return Ok(new { msg = "OK" });
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> EditAddressStatus([FromForm] AddressRequest2 addressRequest2)
        {
            var addresses = addressRequest2.Adapt<Address>();
            await addressService.EditAddressStatus(addresses);
            return Ok(new { msg = "OK" });
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<Address>> UpdateAddress([FromForm] AddressInformationRequest addressInformationRequest)
        {
            var result = await addressService.GetByID(addressInformationRequest.ID);
            if (result == null)
            {
                return Ok(new { msg = "ไม่พบที่อยู่" });
            }


            var address = addressInformationRequest.Adapt(result);
            //var address = addressInformationRequest.Adapt(result);
            await addressService.UpdateAddress(address);
            return Ok(new { msg = "OK", data = address });
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> DeleteAddress(string ID)
        {
            var result = await addressService.GetByID(ID);
            if (result == null)
            {
                return Ok(new { msg = "ไม่พบที่อยู่" });
            }

            await addressService.DeleteAddress(result);
            return Ok(new { msg = "OK", data = result });
        }
    }
}
