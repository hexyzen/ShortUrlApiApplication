using Microsoft.EntityFrameworkCore;
using ShortUrl.Accessors.Context;
using ShortUrl.Accessors.Entities;
using ShortUrl.Managers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortUrl.Managers.Accessors
{
    public class UrlAccessor : IUrlAccessor
    {
        private readonly ShortUrlContext _context;

        public UrlAccessor(ShortUrlContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Url>> GetAllUrlsAsync()
        {
            return await _context.Urls.ToListAsync();
        }

        public async Task<Url> GetUrlByIdAsync(int id)
        {
            return await _context.Urls.FirstOrDefaultAsync(url => url.Id == id);
        }

        public async Task CreateUrlAsync(Url url)
        {
            _context.Urls.Add(url);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUrlAsync(Url url)
        {
            _context.Urls.Update(url);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUrlAsync(int id)
        {
            var url = await _context.Urls.FirstOrDefaultAsync(url => url.Id == id);
            if (url != null)
            {
                _context.Urls.Remove(url);
                await _context.SaveChangesAsync();
            }
        }
    }
}
