using System.ComponentModel.DataAnnotations;

namespace ShopSuphan.Models
{
    public class Information
    {
        [Key]
        public int ID { get; set; }
        public string Nameinformation { get; set; }
        public string Detaiinformation { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public string? Image { get; set; }


    }
}
