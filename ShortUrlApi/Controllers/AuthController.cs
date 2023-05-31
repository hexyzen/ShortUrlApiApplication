using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ShortUrl.Accessors.Entities;
using ShortUrl.Accessors.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ShortUrlApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        public readonly IConfiguration _configuration;
        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
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

        public async Task<IActionResult> Login([FromBody] UserLogin userLogin)
        {
            Account userInfo = Accounts.SingleOrDefault(u => u.UserName == userLogin.Username && u.Password == userLogin.Password);
            if (userInfo == null)
            {
                return StatusCode(StatusCodes.Status401Unauthorized);

            }
            if (userInfo != null)
            {
                string token = await CreateUserJWTAcessToken(userInfo.UserName, userInfo.Id);
                return Ok(token);
            }
            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized);
            }
        }

        private async Task<string> CreateUserJWTAcessToken(string userName, int userId)
        {
            var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("UserName", userName),
                    new Claim("UserId", userId.ToString()),
                };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                 _configuration["Jwt:Issuer"],
                 _configuration["Jwt:Audience"],
               claims,
                  expires: DateTime.UtcNow.AddDays(10),
                  signingCredentials: signIn);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
