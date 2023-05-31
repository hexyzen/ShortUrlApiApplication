using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ShortUrl.Accessors.Services.Interfaces
{
    public interface IJwtClaimsService
    {
        public int GetUserId(ClaimsIdentity identity);
    }
}
