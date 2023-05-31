using ShopSuphan.DTOS.Report;

namespace ShopSuphan.interfaces
{
    public interface IReportService
    {
        Task<List<ProductStatisticsDTO>> ProductStatistics();
        Task<SalesStatisticsDTO> SalesStatistics();
        Task<SalesCommunityDTO> SalesCommunity(int? date);

    }
}
