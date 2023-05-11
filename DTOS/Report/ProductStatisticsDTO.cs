using ShopSuphan.Models;

namespace ShopSuphan.DTOS.Report
{
    public class ProductStatisticsDTO
    {
        public Product Product { get; set; }
        public double? NumPercen { get; set; }
        public double? Amount { get; set; }
    }
}
