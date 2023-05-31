using ShortUrl.Accessors.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ShortUrl.Accessors.Services.Implementation
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
