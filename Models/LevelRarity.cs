using System.ComponentModel.DataAnnotations;

namespace ShopSuphan.Models
{
    public class LevelRarity
    {
        [Key]
        public int ID { get; set; }
        public string LevelRarityName { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;
    }
}
