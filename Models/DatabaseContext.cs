using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using ShopSuphan.Models.OrderAggregate;

namespace ShopSuphan.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<Account> Account { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<CategoryProduct> CategoryProduct { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<OrderAccount> OrderAccount { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<ProductDescription> ProductDescription { get; set; }
        public DbSet<CommunityGroup> CommunityGroup { get; set; }
        public DbSet<LevelRarity> LevelRarity { get; set; }
        public DbSet<AccountPassword> AccountPassword { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ReviewImage> ReviewImages { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<AddressInformation> AddressInformation { get; set; }
        public DbSet<StatusAddress> StatusAddress { get; set; }
        public DbSet<Information> Informations { get; set; }

        //สร้างข้อมูลเริ่มต้นให้กับ Role
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Role>()
               .HasData(
                   new Role { ID = 1, Name = "User" },
                   new Role { ID = 2, Name = "Admin" }
               );

            builder.Entity<CategoryProduct>()
            .HasData(
                new CategoryProduct { ID = 2, Name = "category-01" },
                new CategoryProduct { ID = 3, Name = "category-02" },
                new CategoryProduct { ID = 999, Name = "rare" }
            );
            builder.Entity<CommunityGroup>()
            .HasData(

                new CommunityGroup { ID = 1, CommunityGroupName = "เอกชัย" ,District = "เมือง", SubDistrict = "ท่าระหัด" },
                new CommunityGroup { ID = 2, CommunityGroupName = "ตลาดอู่ทอง", District = "อู่ทอง", SubDistrict = "อู่ทอง" }
            );
            builder.Entity<LevelRarity>()
           .HasData(
               new LevelRarity { ID = 1, LevelRarityName = "หาได้ทั่วไป", Date = DateTime.Now },
               new LevelRarity { ID = 2, LevelRarityName = "ปานกลาง", Date = DateTime.Now },
               new LevelRarity { ID = 3, LevelRarityName = "หายาก", Date = DateTime.Now }
           );
            builder.Entity<StatusAddress>()
        .HasData(
            new StatusAddress { ID = 1, Name = "เป็นได้เเค่พี่น้อง" },
            new StatusAddress { ID = 2, Name = "เป็นได้เเค่เพื่อน" }
        );


        }
    }
}
