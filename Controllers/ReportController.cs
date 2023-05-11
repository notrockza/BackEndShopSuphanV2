using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopSuphan.DTOS.Products;
using ShopSuphan.DTOS.Report;
using ShopSuphan.interfaces;
using ShopSuphan.Services;
using System.Net;

namespace ShopSuphan.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService reportService;

        public ReportController(IReportService reportService)
        {
            this.reportService = reportService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductStatistics()
        {
            var result = await reportService.ProductStatistics();
            return Ok(new { msg = "OK", data = result });
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetSalesStatistics()
        {
            var result = await reportService.SalesStatistics();
            if (result == null) return Ok(new { msg = "ไม่พบสินค้า" });
            return Ok(new { msg = "OK", data = result });
        }
    }
}
