using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShortUrlApi.Interfaces;
using ShortUrlApi.Model;

namespace ShortUrlApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ISecretHasher _secretHasher;

        public AuthController(ISecretHasher secretHasher)
        {
            _secretHasher = secretHasher;

        }


        private List<Account> Accounts => new List<Account>
        {
            new Account()
            {
                Id = 2,
                Email = "user@email.com",
                UserName= "Test",
                Password = "user",
                RoleId = 1
            },

             new Account()
            {
                Id = 3,
                Email = "admin@email.com",
                UserName= "Admin",
                Password = "admin",
                RoleId = 0
            }


        };

        [Route("login")]
        [HttpPost]

        public IActionResult Login([FromBody]Login request)
        {
            var user = AuthenticateUser(request.Username, request.Password);
            
            if (user != null)
            {
                return BadRequest("The username or password is incorrect.");
            }

            return Unauthorized();
        }

        private Account AuthenticateUser(string email, string password)
        {
            var userlogin = Accounts.SingleOrDefault(u => u.Email == email);
            if (_secretHasher.Verify(password, userlogin.EncryptedPassword))
            {
                return Accounts.SingleOrDefault(u => u.Email == email && u.Password == password);
            }

            return null;
        }

    }
}
