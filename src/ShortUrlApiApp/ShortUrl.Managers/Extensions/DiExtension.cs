using Microsoft.Extensions.DependencyInjection;
using ShortUrl.Managers.Accessors;
using ShortUrl.Managers.Interfaces;
using ShortUrl.Managers.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortUrl.Managers.Extensions
{
    public static class DiExtension
    {
        public static void AddBusinessLogic(this IServiceCollection services)
        {
            services
                .AddScoped<IUrlAccessor, UrlAccessor>()
                .AddScoped<IUrlManager, UrlManager>();
        }
    }
}
