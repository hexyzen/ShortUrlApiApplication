using ShortUrl.Accessors.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortUrl.Managers.Interfaces
{
    public interface IUrlAccessor
    {
        Task<IEnumerable<Url>> GetAllUrlsAsync();
        Task<Url> GetUrlByIdAsync(int id);
        Task CreateUrlAsync(Url url);
        Task UpdateUrlAsync(Url url);
        Task DeleteUrlAsync(int id);
    }
}
