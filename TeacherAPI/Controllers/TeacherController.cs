using Microsoft.AspNetCore.Mvc;
using TeacherAPI.Data;
using TeacherAPI.Models;
using System.Linq;

namespace TeacherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly TeacherDbContext _context;

        public TeacherController(TeacherDbContext context)
        {
            _context = context;
        }

        // ✅ GET: api/Teacher
        [HttpGet]
        public IActionResult GetAllTeachers()
        {
            var teachers = _context.Details
                .Where(d => d.Designation == "Teacher")
                .ToList();

            return Ok(teachers);
        }

        // ✅ GET: api/Teacher/{id}
        [HttpGet("{id}")]
        public IActionResult GetTeacherById(int id)
        {
            var teacher = _context.Details
                .FirstOrDefault(d => d.Id == id && d.Designation == "Teacher");

            if (teacher == null)
                return NotFound("Teacher not found.");

            return Ok(teacher);
        }

        // ✅ POST: api/Teacher
        [HttpPost]
        public IActionResult AddTeacher([FromBody] Details teacher)
        {
            if (teacher == null)
                return BadRequest("Invalid data.");

            teacher.Designation = "Teacher"; // Force designation as Teacher
            _context.Details.Add(teacher);
            _context.SaveChanges();

            return Ok("Teacher added successfully.");
        }

        // ✅ PUT: api/Teacher/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateTeacher(int id, [FromBody] Details updatedTeacher)
        {
            var teacher = _context.Details
                .FirstOrDefault(d => d.Id == id && d.Designation == "Teacher");

            if (teacher == null)
                return NotFound("Teacher not found.");

            teacher.Name = updatedTeacher.Name;
            teacher.DOB = updatedTeacher.DOB;
            teacher.Email = updatedTeacher.Email;
            teacher.Password = updatedTeacher.Password;

            _context.SaveChanges();
            return Ok("Teacher updated successfully.");
        }

        // ✅ DELETE: api/Teacher/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteTeacher(int id)
        {
            var teacher = _context.Details
                .FirstOrDefault(d => d.Id == id && d.Designation == "Teacher");

            if (teacher == null)
                return NotFound("Teacher not found.");

            _context.Details.Remove(teacher);
            _context.SaveChanges();

            return Ok("Teacher deleted successfully.");
        }
    }
}
