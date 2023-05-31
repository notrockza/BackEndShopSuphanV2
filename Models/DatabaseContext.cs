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
                new CategoryProduct { ID = 2, Name = "อาหาร" },
                new CategoryProduct { ID = 3, Name = "เครื่องดื่ม" },
                new CategoryProduct { ID = 4, Name = "เสื้อผ่้า" },
                new CategoryProduct { ID = 5, Name = "น้ำพริก" },
                new CategoryProduct { ID = 999, Name = "rare" }
            );
            builder.Entity<CommunityGroup>()
            .HasData(

                new CommunityGroup { ID = 1, CommunityGroupName = "เอกชัย" ,District = "เมือง", SubDistrict = "ท่าระหัด" , TextHistory  = "\"ร้าน เอกชัย\"  เดิมเป็นร้านขนมเล็กๆ ที่ถือกำเนิดขึ้นในตลาดทรัพย์สิน เมื่อปี 2511 จากร้าน 1 คูหา ที่ผลิตขนมอยู่ไม่กี่ชนิดนัก กลายมาเป็นร้านต้นตำรับความอร่อย ของขนมสาลี่สุพรรณ ที่มีเอกลักษณ์ ทั้งในด้านรสชาติ และความนุ่มเนียนของเนื้อขนม อันเป็นจุดเด่นของ \"สาลี่เอกชัย\" จนได้รับเครื่องหมายรับประกันคุณภาพ ความอร่อย \"เชลล์ชวนชิม\" จาก ม.ร.ว. ถนัดศรี สวัสดิวัฒน์ เมื่อปี 2523" },
                new CommunityGroup { ID = 2, CommunityGroupName = "สาลี่แม่บ๊วย", District = "บางปลาม้า", SubDistrict = "บางปลาม้า", TextHistory= "สาลี่แม่บ๊วยแห่งบางปลาม้า ต้นตำรับแห่งแรกของสาลี่สุพรรณ มีความนุ่ม ความหอมและหวานกำลังดี ราคาไม่แพง สนนราคาถุงละ 40 บาทเท่านั้น ใครต้องการเป็นของฝากกรุณาขับรถไปซื้อที่สุพรรณบุรี เพราะไม่มีวางขายในกรุงเทพฯ และไม่มีสาขาที่ไหน มีที่ร้านแม่บ๊วยที่เดียวเท่านั้น และขอเตือนว่าอย่าไปสายหรือบ่ายเกิน ที่นี่คนแวะซื้อของฝากแน่นร้าน โดยเฉพาะช่วงวันหยุด ขนมสาลี่จะหมดเร็วก่อนเพื่อน ซื้อไม่ทันจะหาว่าไม่เตือน" },
                 new CommunityGroup { ID = 3, CommunityGroupName = "ตั้งกุ้ยกี่", District = "บางปลาม้า", SubDistrict = "บางปลาม้า", TextHistory = "ต้นตำหรับ ขนมเปี๊ยะสูตรโบราณ ขนมจันอับ ถ้าได้มาเที่ยวชมตลาดเก้าห้อง 100 ปี ลองแวะไปชิม รับรองว่าคุณต้องติดใจ กับรดชาดดั่งเดิมแถมราคาถูก เหมาะกับเป็นของฝาก" },
                  new CommunityGroup { ID = 4, CommunityGroupName = "อโลเวร่า", District = "ศรีประจันต์ ", SubDistrict = "ศรีประจันต์", TextHistory = "เป็นโรงงานผลิตและจำหน่ายอาหารสมุนไพรเพื่อสุขภาพ บรรจุกระป๋อง\r\nอโลเวร่า ลูกตาล กระจับ แห้ว ใกล้ตลาดเก่าอำเภอศรีประจันต์\r\n612 หมู่3 อ.ศรีประจันต์ จ.สุพรรณบุรี" }
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
