using ShortUrlApi.Interfaces;
using System.Security.Claims;

namespace ShortUrlApi.Implementations
{
    public class JwtClaimsService : IJwtClaimsService
    {
        public int GetUserId(ClaimsIdentity identity) 
        {
            if (identity != null)
            {
                var userClaims = identity.Claims;

                return Convert.ToInt32(userClaims.FirstOrDefault(o => o.Type == "UserId")?.Value);

            }
            return 0;
        }
    }
}
