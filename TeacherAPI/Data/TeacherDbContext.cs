using Microsoft.EntityFrameworkCore;
using TeacherAPI.Models;

namespace TeacherAPI.Data
{
    public class TeacherDbContext : DbContext
    {
        public TeacherDbContext(DbContextOptions<TeacherDbContext> options) : base(options) { }

        public DbSet<Details> Details { get; set; }
    }
}
