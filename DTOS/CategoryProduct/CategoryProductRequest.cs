using System.ComponentModel.DataAnnotations;

namespace ShopSuphan.DTOS.CategoryProduct
{
    public class CategoryProductRequest
    {
        //[Required]
        public int ID { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "no more than {1} chars")]
        public string Name { get; set; }

    }
}
