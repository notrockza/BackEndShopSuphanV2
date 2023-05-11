using Microsoft.EntityFrameworkCore;
using ShopSuphan.DTOS.OrderAccount;
using ShopSuphan.Models;
using ShopSuphan.Models.OrderAggregate;
using ShopSuphan.Settings;

namespace ShopSuphan.Extenstions
{
    public static class OrderExtensions
    {
        public static string PathServer = "https://localhost:7048/images/";
        public static IQueryable<OrderDTO> ProjectOrderToOrderDTO(this IQueryable<OrderAccount> query, DatabaseContext db)
        {

            return query
               .Select(order => new OrderDTO
               {
                   ID = order.ID,
                   PaymentStatus = order.PaymentStatus,
                   Created = order.Created,
                   ProofOfPayment = !string.IsNullOrEmpty(order.ProofOfPayment) ? ServerURLcs.URLServer + "images/" + order.ProofOfPayment : "",
                   PriceTotal = order.PriceTotal,
                   DeliveryFee = order.DeliveryFee,
                   AccountStatus = order.AccountStatus,
                   AddressID = order.AddressID,
                   Address = order.Address,
                   OrderItems = db.OrderItem.Where(e => e.OrderAccountID == order.ID).Select(item => new OrderItemV2DTO
                   {
                       ID = item.ID,
                       OrderAccountID = item.OrderAccountID,
                       ProductID = item.ProductID,
                       Product = item.Product,
                       //ProductImg = PathServer + item.Product.Image,
                       ProductPrice = item.ProductPrice,
                       ProductAmount = item.ProductAmount,
                       //Product = db.Product.Where(e => e. === item.ProductID).Select(itme => new ),


                   }).ToList()
               })
               .AsNoTracking()
               ;
        }
    }
}
