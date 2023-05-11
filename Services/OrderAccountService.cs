using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ShopSuphan.DTOS.OrderAccount;
using ShopSuphan.DTOS.ProductList;
using ShopSuphan.Extenstions;
using ShopSuphan.interfaces;
using ShopSuphan.Models;
using ShopSuphan.Models.OrderAggregate;

namespace ShopSuphan.Services
{
    public class OrderAccountService : IOrderAccountService
    {
        private readonly DatabaseContext databaseContext;
        private readonly IUploadFileService uploadFileService;
        public OrderAccountService(DatabaseContext databaseContext, IUploadFileService uploadFileService)
        {
            this.databaseContext = databaseContext;
            this.uploadFileService = uploadFileService;
        }
        public async Task AddOrder(ProductListOrderRequest productListOrderRequest)
        {
            List<OrderItem> orderItems = new();
            OrderAccount order = new()
            {
                ID = GenerateID(),
                Created = DateTime.Now,
                AddressID = productListOrderRequest.AddrrssID,
                PriceTotal = 0,
                ProofOfPayment = "",
                AccountStatus = false,
                PaymentStatus = Paymentstatus.WaitingForPayment
            };

            foreach (var item in productListOrderRequest.Items)
            {
                var product = await databaseContext.Product.FirstOrDefaultAsync(e => e.ID == item.ProductID);
                product.Stock -= item.ProductAmount;
                orderItems.Add(new OrderItem
                {
                    ProductAmount = item.ProductAmount,
                    OrderAccountID = order.ID,
                    ProductID =item.ProductID,
                    ProductPrice = item.ProductPrice,
                    ID= GenerateID(),

                });
                if (!string.IsNullOrEmpty(item.CartID))
                    databaseContext.Remove(await databaseContext.Cart.FirstOrDefaultAsync(e => e.ID == item.CartID));
            }
            var subtotal = orderItems.Sum(item => item.ProductPrice * item.ProductAmount);
            var deliveryFee = subtotal > 10000 ? 0 : 500;
            order.PriceTotal = subtotal;
            order.DeliveryFee = deliveryFee;
           
            await databaseContext.AddAsync(order);
            await databaseContext.AddRangeAsync(orderItems);

            

            await databaseContext.SaveChangesAsync();
        }

        private string GenerateID() => Guid.NewGuid().ToString("N");

        public async Task ConfirmOrder(List<OrderAccount> orderAccounts)
        {
            for (var i = 0; i < orderAccounts.Count(); i++)
            {
                orderAccounts[i].PaymentStatus = Paymentstatus.SuccessfulPayment;
                databaseContext.Update(orderAccounts[i]);
            }
            await databaseContext.SaveChangesAsync();
        }

        public async Task DeleteImage(string fileName)
        {
            await uploadFileService.DeleteImage(fileName);
        }

        public async Task<IEnumerable<OrderDTO>> GetAll(int idAccount)
        {
            return await databaseContext.OrderAccount.Include(e => e.Address).ProjectOrderToOrderDTO(databaseContext).Where(e => e.Address.AccountID == idAccount).ToListAsync();
        }

        public async Task<IEnumerable<OrderItem>> GetAllProductList(string idOrder)
        {
            return await databaseContext.OrderItem.Include(e => e.Product).Where(e => e.OrderAccountID == idOrder).ToListAsync();
        }

        public async Task<OrderAccount> GetByID(string id)
        {
            var result = await databaseContext.OrderAccount.AsNoTracking().FirstOrDefaultAsync(e => e.ID == id);
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public async Task<IEnumerable<OrderDTO>> GetConfirm()
        {
            var result = await databaseContext.OrderAccount.Include(e => e.Address).ProjectOrderToOrderDTO(databaseContext).Where(e => e.ProofOfPayment != null && e.PaymentStatus == Paymentstatus.PendingApproval).ToListAsync();
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public async Task UpdateOrder(OrderAccount orderAccount)
        {
            databaseContext.Update(orderAccount);
            await databaseContext.SaveChangesAsync();
        }

        public async Task<(string errorMessage, string imageName)> UploadImage(IFormFileCollection formFiles)
        {
            var errorMessage = string.Empty;
            //var imageName = new List<string>();
            var imageName = string.Empty;
            if (uploadFileService.IsUpload(formFiles))
            {
                errorMessage = uploadFileService.Validation(formFiles);
                if (string.IsNullOrEmpty(errorMessage))
                {
                    imageName = (await uploadFileService.UploadImages(formFiles))[0];
                }
            }
            return (errorMessage, imageName);
        }

        public async Task<string> GenerateIdProductListr()
        {
            Random randomNumber = new Random();
            string IdProductListr = "";
            // while คือ roobที่ไมมีที่สิ้นสุดจนกว่าเราจะสั่งให้หยุด
            while (true)
            {
                int num = randomNumber.Next(1000000);

                IdProductListr = DateTime.Now.ToString("yyyy-MM-ddTHH-mm-ss") + "-" + num;


                var result = await databaseContext.OrderItem.FindAsync(IdProductListr);

                if (result == null)
                {
                    break;
                };
            }
            return IdProductListr;
        }

        public async Task<string> GenerateIdOrderCustomer()
        {
            Random randomNumber = new Random();
            string IdProductListr = "";
            // while คือ roobที่ไมมีที่สิ้นสุดจนกว่าเราจะสั่งให้หยุด
            while (true)
            {
                int num = randomNumber.Next(1000000);

                IdProductListr = DateTime.Now.ToString("yyyy-MM-ddTHH-mm-ss") + "-" + num;


                var result = await databaseContext.OrderAccount.FindAsync(IdProductListr);

                if (result == null)
                {
                    break;
                };
            }
            return IdProductListr;
        }

        public async Task<IEnumerable<OrderDTO>> GetConfirmOrderAccount(int idAccount)
        {
            var result = await databaseContext.OrderAccount.Include(e => e.Address).ProjectOrderToOrderDTO(databaseContext).Where(e => e.Address.AccountID == idAccount).Where(e => e.ProofOfPayment != null && e.PaymentStatus == Paymentstatus.SuccessfulPayment).ToListAsync();
            if (result == null)
            {
                return null;
            }
            return result;
        }
    }
}
