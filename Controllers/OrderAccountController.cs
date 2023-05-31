﻿using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopSuphan.DTOS.OrderAccount;
using ShopSuphan.DTOS.ProductList;
using ShopSuphan.interfaces;
using ShopSuphan.Models.OrderAggregate;

namespace ShopSuphan.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderAccountController : ControllerBase
    {
        private readonly IOrderAccountService orderAccountService;

        public OrderAccountController(IOrderAccountService orderAccountService)
        {
            this.orderAccountService = orderAccountService;
        }

        [HttpGet("[action]/{idAccount}")]
        public async Task<IActionResult> GetAll(int idAccount)
        {

            return Ok(await orderAccountService.GetAll(idAccount));
        }

        [HttpGet("[action]/{idAccount}")]
        public async Task<IActionResult> GetByID(string idOrder)
        {
            return Ok(OrderAccountResponse.FromOrder(await orderAccountService.GetByID(idOrder)));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetConfirmOrder()
        {
            var result = (await orderAccountService.GetConfirm());
            if (result == null)
            {
                return Ok(new { msg = "ไม่พบข้อมูล" });
            }

            return Ok(new { msg = "OK", data = result });
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> ConfirmOrder([FromForm] ConfrimOrderAccountRequest confrimOrderAccountRequest)
        
        {
            List<OrderAccount> orderAccount = new List<OrderAccount>();

            
                var result = (await orderAccountService.GetByID(confrimOrderAccountRequest.ID)).Adapt<OrderAccount>();
                if (result == null)
                {
                    return Ok(new { msg = "ไม่พบข้อมูล" });
                }
                orderAccount.Add(result);
            
            await orderAccountService.ConfirmOrder(orderAccount);
            return Ok(new { msg = "OK" });
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddOrderCustomer([FromBody] ProductListOrderRequest productListOrderRequest)
        {
       
            await orderAccountService.AddOrder(productListOrderRequest);
            return Ok(new { msg = "OK" });
        }

        [HttpGet("[action]/{idOrder}")]
        public async Task<IActionResult> GetAllProductList(string idOrder)
        {
            var data = (await orderAccountService.GetAllProductList(idOrder)).Select(ProductListResponse.FromProductList);
            return Ok(data);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> PaymentOrder([FromForm] OrderPaymentRequest orderPaymentRequest)
        {
            var result = await orderAccountService.GetByID(orderPaymentRequest.ID);
            if (result == null) return Ok(new { msg = "ไม่พบข้อมูล" });
            #region จัดการรูปภาพ
            (string erorrMesage, string imageName) = await orderAccountService.UploadImage(orderPaymentRequest.FormFiles);
            if (!string.IsNullOrEmpty(erorrMesage)) return BadRequest(erorrMesage);
            if (!string.IsNullOrEmpty(imageName))
            {
                if (!string.IsNullOrEmpty(result.ProofOfPayment)) await orderAccountService.DeleteImage(result.ProofOfPayment);
                result.ProofOfPayment = imageName;
            }
            result.PaymentStatus = orderPaymentRequest.PaymentStatus;
            #endregion
            await orderAccountService.UpdateOrder(result); ;
            return Ok(new { msg = "OK", data = result });
        }



        [HttpGet("[action]/{idAccount}")]
        public async Task<IActionResult> GetConfirmOrderAccount(int idAccount)
        {

            return Ok(await orderAccountService.GetConfirmOrderAccount(idAccount));
        }

    }
}
