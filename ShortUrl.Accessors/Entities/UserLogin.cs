using System.ComponentModel.DataAnnotations;

namespace ShortUrl.Accessors.Entities
{
    public class UserLogin
    {
        public int UserId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
