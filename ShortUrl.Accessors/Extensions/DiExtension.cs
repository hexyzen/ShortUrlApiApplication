using Microsoft.Extensions.DependencyInjection;
using ShortUrl.Accessors.Context;

namespace ShortUrl.Accessors.Extensions
{
    public static class DiExtension
    {
        public static void AddDataLayer(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<ShortUrlContext>(_ => new(connectionString));
        }
    }
    
}
