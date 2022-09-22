using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShortUrlApi.Model;

namespace ShortUrlApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private List<Account> Accounts => new List<Account>
        {
            new Account()
            {
                Id = Guid.Parse("e2371dc9-a849-4f3c-9004-df8fc921c13a"),
                Email = "user@email.com",
                Password = "user",
                Roles = new Role[] { Role.User }
            },

             new Account()
            {
                Id = Guid.Parse("e2331dc9-a849-4f3c-9004-df8fc921c13a"),
                Email = "admin@email.com",
                Password = "admin",
                Roles = new Role[] { Role.Admin }
            }


        };

        [Route("login")]
        [HttpPost]

        public IActionResult Login([FromBody]Login request)
        {
            var user = AuthenticateUser(request.Email, request.Password);
            
            if (user != null)
            {

            }

            return Unauthorized();
        }

        private Account AuthenticateUser(string email, string password)
        {
            return Accounts.SingleOrDefault(u => u.Email == email && u.Password == password);
        }

    }
}
