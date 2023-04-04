using System.ComponentModel.DataAnnotations;

namespace ShopSuphan.DTOS.CommunityGroup
{
    public class CommunityGroupRequest
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "no more than {1} chars")]
        public string CommunityGroupName { get; set; }


        [Required]
        [MaxLength(100, ErrorMessage = "no more than {1} chars")]
        public string District { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "no more than {1} chars")]
        public string SubDistrict { get; set; }
    }
}
