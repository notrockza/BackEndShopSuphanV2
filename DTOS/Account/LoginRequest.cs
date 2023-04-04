using System.ComponentModel.DataAnnotations;

namespace ShopSuphan.DTOS.Account
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(4)]
        public string Password { get; set; }
    }
}
