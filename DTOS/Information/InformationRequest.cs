using System.ComponentModel.DataAnnotations;

namespace ShopSuphan.DTOS.Information
{
    public class InformationRequest
    {
        public int? ID { get; set; }
        [Required]
        public string Nameinformation { get; set; }
        [Required]
        public string Detaiinformation { get; set; }
        public IFormFileCollection? FormFiles { get; set; }
    }
}
