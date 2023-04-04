using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShopSuphan.Models
{
    public class Review
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ID { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public string Text { get; set; }
        public int AccountID { get; set; }
        public string ProductListID { get; set; }
        [ForeignKey("ProductListID")]
        public virtual ProductList ProductList { get; set; }

        [ForeignKey("AccountID")]
        public virtual Account Account { get; set; }
    }
}
