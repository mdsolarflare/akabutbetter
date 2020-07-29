#nullable enable
using System;
using System.Threading.Tasks;
using akabutbetter.Helpers;
using akabutbetter.Models;
using Microsoft.AspNetCore.Mvc;
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
        [Route("api/add")]
        [HttpPost]
        public async Task<ActionResult<Shortlink>> PostShortlink([FromForm]ShortlinkRequest? request)
        {
            if (request == null)
            {
                _logger.LogError($"Received a failed shortlink add/post @ {DateTime.Now}");
                return BadRequest("Shortlink is null.");
            }
            
            _logger.LogInformation($"Received shortlink creation request: {request}.");
            
            // if doesn't exist
            Shortlink fromDb = AkaHelper.GetShortlinkFromDb(_context, request.PrettyName);
            if (fromDb  == null)
            {
                await _context.Shortlinks.AddAsync(new Shortlink(request, _context));
                await _context.SaveChangesAsync();
                
                return CreatedAtAction(nameof(Get), new { pretty = request.PrettyName }, request);
            }

            return Unauthorized(fromDb);
        }

        // GET:
        [HttpGet("{pretty}")]
        public void Get(string pretty)
        {
            _logger.LogInformation($"Shortlink name: {pretty} requested at {DateTime.Now}.");

            if (!string.IsNullOrWhiteSpace(pretty))
            {
                Shortlink sl = AkaHelper.GetShortlinkFromDb(_context, pretty);
                Response.Redirect(sl.Destination.ToString());
            }
            else
            {
                AkaHelper.RedirectToLinkManagement();
            }
        }
    }
}