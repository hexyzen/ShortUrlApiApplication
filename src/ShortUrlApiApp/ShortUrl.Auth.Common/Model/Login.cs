using System.ComponentModel.DataAnnotations;

namespace ShortUrlApi.Model
{
    public class Login
    {

        public int UserId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public byte[]? PasswordSec { get; set; }


    }
}
