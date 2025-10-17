using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeacherAPI.Data;
using System.Linq;

namespace TeacherAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly TeacherDbContext _context;

        public StudentController(TeacherDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Policy = "StudentPolicy")]
        public IActionResult GetStudents()
        {
            // Only returns students
            var students = _context.Details.Where(d => d.Designation == "Student").ToList();
            return Ok(students);
        }
    }
}
