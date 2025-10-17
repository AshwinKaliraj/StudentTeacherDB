using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeacherAPI.Data;
using TeacherAPI.Models;
using System.Linq;

namespace TeacherAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly TeacherDbContext _context;

        public TeacherController(TeacherDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Policy = "TeacherPolicy")]
        public IActionResult GetTeachers()
        {
            return Ok(_context.Details.Where(d => d.Designation == "Teacher").ToList());
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "TeacherPolicy")]
        public IActionResult GetTeacher(int id)
        {
            var teacher = _context.Details.FirstOrDefault(d => d.Id == id && d.Designation == "Teacher");
            if (teacher == null) return NotFound();
            return Ok(teacher);
        }

        [HttpPost]
        [Authorize(Policy = "TeacherPolicy")]
        public IActionResult AddTeacher([FromBody] Details teacher)
        {
            teacher.Designation = "Teacher";
            _context.Details.Add(teacher);
            _context.SaveChanges();
            return Ok("Teacher added");
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "TeacherPolicy")]
        public IActionResult UpdateTeacher(int id, [FromBody] Details updated)
        {
            var teacher = _context.Details.FirstOrDefault(d => d.Id == id && d.Designation == "Teacher");
            if (teacher == null) return NotFound();

            teacher.Name = updated.Name;
            teacher.DOB = updated.DOB;
            teacher.Email = updated.Email;
            teacher.Password = updated.Password;

            _context.SaveChanges();
            return Ok("Teacher updated");
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "TeacherPolicy")]
        public IActionResult DeleteTeacher(int id)
        {
            var teacher = _context.Details.FirstOrDefault(d => d.Id == id && d.Designation == "Teacher");
            if (teacher == null) return NotFound();

            _context.Details.Remove(teacher);
            _context.SaveChanges();
            return Ok("Teacher deleted");
        }
    }
}
