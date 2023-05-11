
using ShopSuphan.Models;
using ShopSuphan.Settings;

namespace ShopSuphan.DTOS.Information
{
    public class InformationResponse
    {
        public int? ID { get; set; }
        public string Nameinformation { get; set; }
        public string Detaiinformation { get; set; }
        public DateTime Created { get; set; }
        public string? Image { get; set; }

        static public InformationResponse FromInformation(Models.Information information)
        {
            // return ตัวมันเอง
            return new InformationResponse
            {
                ID = information.ID,
                Nameinformation = information.Nameinformation,  
                Detaiinformation = information.Detaiinformation,
                Created = information.Created,
                Image = !string.IsNullOrEmpty(information.Image) ? ServerURLcs.URLServer + "images/" + information.Image : "",


            };

        }
    }
}
