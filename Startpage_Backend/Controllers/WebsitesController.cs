using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Startpage_Backend.Models;
using Startpage_Backend.Services;

namespace Startpage_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebsitesController : ControllerBase
    {
        private readonly WebsiteService _websiteService;

        public WebsitesController(WebsiteService websiteService)
        {
            _websiteService = websiteService;
        }

        // Actions to support HTTP requests, the WebsiteService is used to perform the CRUD operations
        [HttpGet]
        public ActionResult<List<Website>> Get() =>
            _websiteService.Get();

        [HttpGet("{id:length(24)}", Name = "GetWebsite")]
        public ActionResult<Website> Get(string id)
        {
            var website = _websiteService.Get(id);

            if (website == null)
            {
                return NotFound();
            }

            return website;
        }

        [HttpPost]
        public ActionResult<Website> Create(Website website)
        {
            _websiteService.Create(website);

            return CreatedAtRoute("GetBook", new { id = website.Id.ToString() }, website);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(String id, Website websiteIn)
        {
            var website = _websiteService.Get(id);

            if (website == null)
            {
                return NotFound();
            }

            _websiteService.Update(id, websiteIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var website = _websiteService.Get(id);

            if(website == null)
            {
                return NotFound();
            }

            _websiteService.Remove(website.Id);

            return NoContent();
        }
    }
}
