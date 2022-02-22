using Microsoft.EntityFrameworkCore;
using Day10.Entities;
namespace Day10.Database
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options)
        : base(options) { }
        public DbSet<Student> Students { get; set; }
    }
}