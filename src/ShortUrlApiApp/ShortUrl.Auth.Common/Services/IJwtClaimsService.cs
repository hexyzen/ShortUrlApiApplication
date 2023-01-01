using System.Security.Claims;

namespace ShortUrlApi.Interfaces
{
    public interface IJwtClaimsService
    {
        public int GetUserId(ClaimsIdentity identity);
    }
}

