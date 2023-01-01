using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShortUrlApi.Data;
using ShortUrlApi.Model;

namespace ShortUrlApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinksController : ControllerBase
    {
        private readonly DataContext _context;

        public LinksController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Links
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Link>>> GetLinks()
        {
            return await _context.Links.ToListAsync();
        }

        // GET: api/Links/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Link>> GetLink(int LinkId)
        {
            var link = await _context.Links.FindAsync(LinkId);

            if (link == null)
            {
                return NotFound();
            }

            return link;
        }

        // PUT: api/Links/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLink(int LinkId, Link link)
        {
            if (LinkId != link.LinkId)
            {
                return BadRequest();
            }

            _context.Entry(link).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LinkExists(LinkId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Links
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Link>> PostLink(Link link)
        {
            _context.Links.Add(link);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLink", new { LinkId = link.LinkId }, link);
        }

        // DELETE: api/Links/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLink(int LinkId)
        {
            var link = await _context.Links.FindAsync(LinkId);
            if (link == null)
            {
                return NotFound();
            }

            _context.Links.Remove(link);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LinkExists(int LinkId)
        {
            return _context.Links.Any(e => e.LinkId == LinkId);
        }
    }
}
