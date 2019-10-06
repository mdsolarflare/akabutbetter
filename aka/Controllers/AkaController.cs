using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace akabutbetter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AkaController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<AkaController> _logger;

        public AkaController(ILogger<AkaController> logger)
        {
            _logger = logger;
        }

        [HttpGet("go/{shortname}")]
        public void Get(string shortname)
        {
            Console.WriteLine("shortname:" + shortname);
            string built = "www." + shortname + ".com";
            Response.Redirect(built);
        }
    }
}