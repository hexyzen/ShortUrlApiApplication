using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShortUrl.Accessors.Entities;
using ShortUrl.Accessors.Entities.Dtos;
using ShortUrl.Managers.Interfaces;
using Url = ShortUrl.Accessors.Entities.Url;

namespace ShortUrlApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UrlController : Controller
    {
        private readonly IUrlManager _urlService;

        public UrlController(IUrlManager urlService)
        {
            _urlService = urlService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateUrl([FromBody] Url url)
        {
            var currentUser = await GetThisUserAsync();
            url.CreatedBy = currentUser.Username;
            await _urlService.CreateUrlAsync(url);
            return Ok(url);
        }

        [HttpGet]
        public async Task<ActionResult> GetUrls()
        {
            var urls = await _urlService.GetAllUrlsAsync();
            return Ok(urls);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> GetUrl([Required] int urlId)
        {
            var url = await _urlService.GetUrlByIdAsync(urlId);
            return Ok(url);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateUrl([FromBody] Url url)
        {
            await _urlService.UpdateUrlAsync(url);
            return Ok(url);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteUrl(int LinkId)
        {
            await _urlService.DeleteUrlAsync(LinkId);
            return Ok();
        }

        private async Task<UserLogin> GetThisUserAsync()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;

                return new UserLogin
                {
                    Username = userClaims.FirstOrDefault(o => o.Type == "UserName")?.Value,
                    UserId = Convert.ToInt32(userClaims.FirstOrDefault(o => o.Type == "UserId")?.Value),
                };
            }
            return null;
        }
    }
}
