using System;

namespace TeacherAPI.Models
{
    public class Details
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime DOB { get; set; }
        public string Designation { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
