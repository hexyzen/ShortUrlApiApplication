using ShortUrl.Accessors.Entities;
using ShortUrl.Managers.Exceptions;
using ShortUrl.Managers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortUrl.Managers.Managers
{
    public class UrlManager : IUrlManager
    {
        private readonly IUrlAccessor _urlAccessor;

        public UrlManager(IUrlAccessor urlAccessor)
        {
            _urlAccessor = urlAccessor;
        }

        public async Task<IEnumerable<Url>> GetAllUrlsAsync()
        {
            return await _urlAccessor.GetAllUrlsAsync();
        }

        public async Task<Url> GetUrlByIdAsync(int id)
        {
            return await _urlAccessor.GetUrlByIdAsync(id);
        }

        public async Task CreateUrlAsync(Url url)
        {
            if (url is null)
                throw new EntityNotFoundException(typeof(Url));
            await _urlAccessor.CreateUrlAsync(url);
        }

        public async Task UpdateUrlAsync(Url url)
        {
            if (url is null)
                throw new EntityNotFoundException(typeof(Url));
            await _urlAccessor.UpdateUrlAsync(url);
        }

        public async Task DeleteUrlAsync(int id)
        {
            try
            {
                await _urlAccessor.DeleteUrlAsync(id);
            }
            catch
            {
                throw new EntityNotFoundException(typeof(Url));
            }
        }
    }
}
