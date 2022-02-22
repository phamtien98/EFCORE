using Day10.Entities;
using Day10.DTO;
using Day10.Database;
using Microsoft.EntityFrameworkCore;
namespace Day10.Service
{
    public class StudentService : IStudentService
    {
        private StudentContext _dbContext;
        public StudentService(StudentContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Student> Add(StudentDTO student)
        {
            var addStudent = await _dbContext.Students.AddAsync(new Student
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                City = student.City,
                State = student.State,
            });

            await _dbContext.SaveChangesAsync();
            return addStudent.Entity;

        }

        public async Task<Student> Edit(Student student)
        {
            var item = await _dbContext.Students.FindAsync(student.StudentId);
            if (item != null)
            {
                item.City = student.City;
                item.FirstName = student.FirstName;
                item.LastName = student.LastName;
                item.State = student.State;
                await _dbContext.SaveChangesAsync();
                return item;
            }

            return null;
        }

        public async Task Delete(int id)
        {
            var item = await _dbContext.Students.FindAsync(id);
            if (item != null)
            {
                _dbContext.Students.Remove(item);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Student>> GetAllStudent()
        {
            return await _dbContext.Students.ToListAsync();
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await _dbContext.Students.FirstOrDefaultAsync(m => m.StudentId == id);
        }
    }
}