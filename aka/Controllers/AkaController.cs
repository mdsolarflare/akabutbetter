using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using akabutbetter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace akabutbetter.Controllers
{
    [ApiController]
    public class AkaController : ControllerBase
    {
        private readonly ILogger<AkaController> _logger;
        private readonly AkaContext _context;

        public AkaController(ILogger<AkaController> logger, AkaContext context)
        {
            _logger = logger;
            _context = context;
        }
        
        // POST: api/TodoItems
        /*[HttpPost]
        public async Task<ActionResult<Shortlink>> PostShortlink(Shortlink shortlink)
        {
            _context.Shortlinks.Add(shortlink);
            await _context.SaveChangesAsync();
            
            return CreatedAtAction(nameof(GetShortlink), new { id = shortlink.LinkId }, shortlink);
        }*/

        // GET:
        [HttpGet("{shortname}")]
        public void Get(string shortname)
        {
            Console.WriteLine($"shortname: {shortname} requested.");
            string built = "http://www." + shortname + ".com";
            Response.Redirect(built);
        }
    }
}