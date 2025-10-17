using System;
using System.ComponentModel.DataAnnotations;

namespace TeacherAPI.Models
{
    public class Details
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required]
        public string Designation { get; set; }  // "Teacher" or "Student"

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
