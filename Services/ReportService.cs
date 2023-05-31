using Microsoft.EntityFrameworkCore;
using ShopSuphan.DTOS.Report;
using ShopSuphan.interfaces;
using ShopSuphan.Models;
using ShopSuphan.Models.OrderAggregate;

namespace ShopSuphan.Services
{
    public class ReportService : IReportService
    {
        private readonly DatabaseContext databaseContext;
        public ReportService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task<List<ProductStatisticsDTO>> ProductStatistics()
        {
            List<ProductStatisticsDTO> ProductStatistics = new();
            List<OrderItem> orderItems = new();
            var orders = await databaseContext.OrderAccount.ToListAsync();
            foreach (var order in orders)
            {
                var items = databaseContext.OrderItem.Where(e => e.OrderAccountID.Equals(order.ID)).ToList();
                if (items?.Count() > 0)
                    orderItems.AddRange(items);
            };
            foreach (var item in orderItems)
            {
                var product = await databaseContext.Product.AsNoTracking().FirstOrDefaultAsync(e => e.ID == item.ProductID);
                if (product is not null)
                {
                    var checkProduct = ProductStatistics.FirstOrDefault(e => e.Product.ID == product.ID);
                    if (checkProduct is null)
                        ProductStatistics.Add(new ProductStatisticsDTO { Amount = item.ProductAmount, Product = product });
                    else checkProduct.Amount += item.ProductAmount;
                };
            };
            var sum = ProductStatistics.Sum(e => e.Amount);
            foreach (var item in ProductStatistics) item.NumPercen = item.Amount * 100 / sum;
            return ProductStatistics;
        }


        public async Task<SalesStatisticsDTO> SalesStatistics()
        {
            SalesStatisticsDTO salesStatisticsDTO = new();
            List<OrderItem> orderItems = new();
            var orders = await databaseContext.OrderAccount.ToListAsync();
            foreach (var order in orders)
            {
                var items = databaseContext.OrderItem.Where(e => e.OrderAccountID.Equals(order.ID)).ToList();
                if (items?.Count() > 0)
                    orderItems.AddRange(items);


                var result = salesStatisticsDTO.Sales.Find(x => x.Month == order.Created.Month && x.Year == order.Created.Year);
                if (result == null)
                {
                    salesStatisticsDTO.Sales.Add(new SalesStatisticeItemDTO
                    {
                        price = order.PriceTotal,
                        FullTime = order.Created,
                        Day = order.Created.Day,
                        Month = order.Created.Month,
                        Year = order.Created.Year
                    });
                }
                else result.price += order.PriceTotal;
            };


            salesStatisticsDTO.TotalPrice = salesStatisticsDTO.Sales.Sum(e => e.price);
            foreach (var item in salesStatisticsDTO.Sales)
            {
                var Percen = item.price * 100 / salesStatisticsDTO.TotalPrice;
                item.percent = Percen;
            }
            salesStatisticsDTO.Sales = salesStatisticsDTO.Sales.OrderByDescending(e => e.Month).ToList();


            return salesStatisticsDTO;

        }


        public async Task<SalesCommunityDTO> SalesCommunity(int? date)
        {

            SalesCommunityDTO salesCommunityDTO = new();
            List<OrderItem> orderItems = new();
            var orders = await databaseContext.OrderAccount.Where(e =>
            e.ProofOfPayment != null && e.PaymentStatus == Paymentstatus.SuccessfulPayment &&
            e.Created.Year == (date == 0 || date == null ? DateTime.Now.Year : date)
            ).ToListAsync();
            foreach (var order in orders)
            {
                var items = databaseContext.OrderItem
                    .Include(e => e.Product).ThenInclude(e => e.CommunityGroup).Where(e => e.OrderAccountID.Equals(order.ID)).ToList();
                if (items?.Count() > 0)
                {
                    foreach (var item in items)
                    {
                        var check = salesCommunityDTO.Sales.FirstOrDefault(e => e.CommunityId == item.Product.CommunityGroupID);
                        if (check != null)
                        {
                            check.price += (item.ProductPrice * item.ProductAmount);
                        }
                        else
                        {
                            salesCommunityDTO.Sales.Add(new SalesCommunityItemDTOcs { price = (item.ProductPrice * item.ProductAmount), CommunityId = item.Product.CommunityGroup.ID, CommunityName = item.Product.CommunityGroup.CommunityGroupName, });
                        }
                    }
                }
            };

            salesCommunityDTO.TotalPrice = salesCommunityDTO.Sales.Sum(e => e.price);
            foreach (var item in salesCommunityDTO.Sales)
            {
                var Percen = item.price * 100 / salesCommunityDTO.TotalPrice;
                item.percent = Percen;
            }
            salesCommunityDTO.Sales = salesCommunityDTO.Sales.OrderByDescending(e => e.price).ToList();

            return salesCommunityDTO;
        }
    }
}
