using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeacherAPI.Data;
using TeacherAPI.Models;
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

        // GET: api/Student
        [HttpGet]
        [Authorize(Policy = "StudentPolicy")]
        public IActionResult GetStudents()
        {
            // Only return records with Designation = "Student"
            var students = _context.Details
                .Where(d => d.Designation == "Student")
                .ToList();

            return Ok(students);
        }
    }
}
