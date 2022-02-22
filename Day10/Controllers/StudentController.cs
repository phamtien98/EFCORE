using Microsoft.AspNetCore.Mvc;
using Day10.Service;
using Day10.DTO;
using Day10.Entities;
namespace Day10.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost("/add-student")]
        public async Task<Student> Add(StudentDTO student)
        {
            return await _studentService.Add(student);
        }

        [HttpPut("/edit-student")]
        public async Task<Student> Edit(Student student)
        {
            return await _studentService.Edit(student);
        }

        [HttpDelete("/delete-student")]
        public async Task Delete(int id)
        {
            await _studentService.Delete(id);
        }

        [HttpGet("/get-all-student")]
        public async Task<List<Student>> GetAllStudent()
        {
            return await _studentService.GetAllStudent();
        }

        [HttpGet("/get-student-by-id")]
        public async Task<Student> GetStudentById(int id)
        {
            return await _studentService.GetStudentById(id);
        }
    }
}