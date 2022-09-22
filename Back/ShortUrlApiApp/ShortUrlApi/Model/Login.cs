using System.ComponentModel.DataAnnotations;

namespace ShortUrlApi.Model
{
    public class Login
    {
        [Required]
        [EmailAddress]

        public string Email { get; set; }

        [Required]
        public string Password {  get; set; }

    }
}
