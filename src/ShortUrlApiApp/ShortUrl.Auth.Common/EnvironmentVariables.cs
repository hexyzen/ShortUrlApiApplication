using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortUrl.Common
{
    public static class EnvironmentVariables
    {
        public static readonly string ConnectionString = "server=localhost\\sqlexpress;database=shorturlapidb;trusted_connection=true";
    }
}
