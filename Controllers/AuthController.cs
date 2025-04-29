using Microsoft.AspNetCore.Mvc;
using WebinarBackend.Models;
using WebinarBackend.Data;
using Microsoft.EntityFrameworkCore;

namespace WebinarBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly WebinarDbContext _context;

        public AuthController(WebinarDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
                return BadRequest("Username and password are required.");

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == request.Username);
            if (user == null)
                return Unauthorized("Invalid credentials");

            bool valid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
            if (!valid)
                return Unauthorized("Invalid credentials");

            return Ok(new
            {
                identity = user.Username,
                role = user.Role
            });
        }

        [HttpPost("register")]
public async Task<IActionResult> Register([FromBody] LoginRequest request)
{
    if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
        return BadRequest("Username and password are required.");

    if (await _context.Users.AnyAsync(u => u.Username == request.Username))
        return Conflict("Username already exists.");

    var user = new User
    {
        Username = request.Username,
        PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
        Role = "student"
    };

    _context.Users.Add(user);
    await _context.SaveChangesAsync();

    return Ok(new { message = "Student registered successfully" });
}

    }
}
