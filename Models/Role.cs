using System.ComponentModel.DataAnnotations;

namespace ShopSuphan.Models
{
    public class Role
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
