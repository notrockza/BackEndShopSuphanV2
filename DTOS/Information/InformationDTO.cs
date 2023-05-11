using System.ComponentModel.DataAnnotations;

namespace ShopSuphan.DTOS.Information
{
    public class InformationDTO
    {
        public int? ID { get; set; }
        public string Nameinformation { get; set; }
        public string Detaiinformation { get; set; }
        public DateTime Created { get; set; } 
        public string? Image { get; set; }

    }
}
