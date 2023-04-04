using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShopSuphan.Models
{
    public class AccountPassword
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ID { get; set; }
        public int AccountID { get; set; }
        public string Password { get; set; }
        [ForeignKey("AccountID")]
        public virtual Account Account { get; set; }
    }
}
