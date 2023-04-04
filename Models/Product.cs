using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopSuphan.Models
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string Detail { get; set; }
        public string? Image { get; set; }
        public int CategoryProductID { get; set; }
        [ForeignKey("CategoryProductID")]
        public virtual CategoryProduct CategoryProduct { get; set; }

        public int CommunityGroupID { get; set; }
        [ForeignKey("CommunityGroupID")]
        public virtual CommunityGroup CommunityGroup { get; set; }

        public int LevelRarityID { get; set; }
        [ForeignKey("LevelRarityID")]
        public virtual LevelRarity LevelRarity { get; set; }

    }
}

