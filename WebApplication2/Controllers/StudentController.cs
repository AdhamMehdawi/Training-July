using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.DataAccess;
using WebApplication2.DataAccess.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
         private readonly MyDatabase _context;

        public StudentController(MyDatabase context)
        {
            _context = context;
        }
        [HttpGet("GetAllStudents")]
        public IActionResult GetAllStudents()
        {
            var students = _context.Students.ToList();
            if(students == null)
            {
                return Ok("The system dose not have any students yet");
            }
            return Ok(students);
        }

        [HttpGet("GetStudentById")]
        public IActionResult GetStudentById(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return Ok("student dose not exist");
            }
            return Ok(student);
        }

        [HttpPost("AddStudent")]
        public IActionResult AddStudent(StudentDt student)
        {
            if (student == null)
            {
                return BadRequest();
            }
            var stu = new StudentModel()
            {
               
                Name = student.Name,
                Email = student.Email,
                PhoneNumber = student.Phone,
                City = student.City
            };

            _context.Students.Add(stu);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("DeleteStudent")]
        public IActionResult DeleteStudent(int id)
        {
           var student = _context.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return Ok("student dose not exist");
            }
            _context.Students.Remove(student);
            _context.SaveChanges();
            return Ok("the student deleted successfuly");
        }

        [HttpPut("UpdateStudent")]
        public IActionResult UpdateStudent(StudentDt student)
        {
            if (student == null)
            {
                return BadRequest();
            }
            var stu = _context.Students.FirstOrDefault(s => s.Id == student.Id);
            if (stu == null)
            {
                return Ok("student dose not exist");
            }
            stu.Id = student.Id;
            stu.Name = student.Name;
            stu.Email = student.Email;
            stu.PhoneNumber = student.Phone;
            stu.City = student.City;
            _context.SaveChanges();
            return Ok();
        }


    }
}
