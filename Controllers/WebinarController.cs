using Microsoft.AspNetCore.Mvc;
using WebinarBackend.Data;
using WebinarBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace WebinarBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WebinarController : ControllerBase
    {
        private readonly WebinarDbContext _context;

        public WebinarController(WebinarDbContext context)
        {
            _context = context;
        }

        [HttpPost("start")]
        public async Task<IActionResult> StartWebinar([FromQuery] string webinarId)
        {
            if (string.IsNullOrWhiteSpace(webinarId))
                return BadRequest("Invalid Webinar ID");

            // Check if already exists
            bool alreadyExists = await _context.Webinars.AnyAsync(w => w.WebinarId == webinarId);
            if (!alreadyExists)
            {
                _context.Webinars.Add(new Webinar { WebinarId = webinarId });
                await _context.SaveChangesAsync();
            }

            return Ok(new { message = "Webinar started." });
        }

        [HttpGet("check/{webinarId}")]
        public async Task<IActionResult> CheckWebinar(string webinarId)
        {
            bool exists = await _context.Webinars.AnyAsync(w => w.WebinarId == webinarId);
            return Ok(new { exists });
        }
    }
}
