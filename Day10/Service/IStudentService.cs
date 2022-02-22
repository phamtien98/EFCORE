using Day10.DTO;
using Day10.Entities;
namespace Day10.Service
{
    public interface IStudentService
    {
        Task<Student> Add(StudentDTO student);
        Task<Student> Edit(Student student);
        Task Delete(int id);
        Task<List<Student>> GetAllStudent();
        Task<Student> GetStudentById(int id);
    }
}