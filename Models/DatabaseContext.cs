using Microsoft.EntityFrameworkCore;


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
        public DbSet<ProductList> ProductList { get; set; }
        public DbSet<ProductDescription> ProductDescription { get; set; }
        public DbSet<CommunityGroup> CommunityGroup { get; set; }
        public DbSet<LevelRarity> LevelRarity { get; set; }
        public DbSet<AccountPassword> AccountPassword { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ReviewImage> ReviewImages { get; set; }
    }
}
