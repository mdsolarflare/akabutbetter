using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using akabutbetter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace akabutbetter.Controllers
{
    [ApiController]
    public class AkaController : ControllerBase
    {
        private readonly ILogger<AkaController> _logger;

        public AkaController(ILogger<AkaController> logger)
        {
            _logger = logger;
        }
        
        // POST: api/TodoItems
        [HttpPost]
        public async Task<ActionResult<Shortlink>> PostTodoItem(Shortlink todoItem)
        {
            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
        }

        // GET:
        [HttpGet("{shortname}")]
        public void Get(string shortname)
        {
            Console.WriteLine("shortname:" + shortname);
            string built = "http://www." + shortname + ".com";
            Response.Redirect(built);
        }
    }
}