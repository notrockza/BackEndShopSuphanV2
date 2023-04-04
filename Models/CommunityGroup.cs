using System.ComponentModel.DataAnnotations;

namespace ShopSuphan.Models
{
    public class CommunityGroup
    {
        [Key]
        public int ID { get; set; }
        public string CommunityGroupName { get; set; }
        public string District { get; set; }
        public string SubDistrict { get; set; }
        
    }
    
}
