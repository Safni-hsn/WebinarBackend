using Microsoft.AspNetCore.Mvc;
using WebinarBackend.Data;
using System.Linq;

namespace WebinarBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly WebinarDbContext _context;

        public StudentsController(WebinarDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var students = _context.Users
                .Where(u => u.Role == "student")
                .Select(u => new 
                {
                    Username = u.Username // 🔥 Correct field!
                })
                .ToList();

            return Ok(students);
        }
    }
}
