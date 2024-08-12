using Microsoft.AspNetCore.Mvc;
using WebApplication2.Entities;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.DTOs;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<StudentDTO>> GetAll()
        {
            var students = _context.Students
                .Select(s => new StudentDTO
                {
                    Id = s.Id,
                    Name = s.Name,
                    Email = s.Email,
                    PhoneNumber = s.PhoneNumber,
                    City = s.City
                })
                .ToList();

            return Ok(students);
        }

        [HttpGet("{id}")]
        public ActionResult<StudentDTO> Get(int id)
        {
            var student = _context.Students
                .Select(s => new StudentDTO
                {
                    Id = s.Id,
                    Name = s.Name,
                    Email = s.Email,
                    PhoneNumber = s.PhoneNumber,
                    City = s.City
                })
                .FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost]
        public ActionResult<StudentDTO> Post([FromBody] StudentDTO studentModelDTO)
        {
            if (studentModelDTO == null)
            {
                return BadRequest();
            }

            var student = new StudentModel
            {
                Name = studentModelDTO.Name,
                Email = studentModelDTO.Email,
                PhoneNumber = studentModelDTO.PhoneNumber,
                City = studentModelDTO.City
            };

            _context.Students.Add(student);
            _context.SaveChanges();

            studentModelDTO.Id = student.Id;

            return CreatedAtAction(nameof(Get), new { id = studentModelDTO.Id }, studentModelDTO);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] StudentDTO studentModelDTO)
        {
            if (studentModelDTO == null || id != studentModelDTO.Id)
            {
                return BadRequest();
            }

            var existingStudent = _context.Students.Find(id);
            if (existingStudent == null)
            {
                return NotFound();
            }

            existingStudent.Name = studentModelDTO.Name;
            existingStudent.Email = studentModelDTO.Email;
            existingStudent.PhoneNumber = studentModelDTO.PhoneNumber;
            existingStudent.City = studentModelDTO.City;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            _context.SaveChanges();

            return NoContent();
        }
        [HttpGet("GetStudentsByTeacherAndCourse")]
        public async Task<ActionResult<List<StudentDTO>>> GetStudentsByTeacherAndCourse(string teacherName, string courseName)
        {
            var students = await _context.Students
                .Include(s => s.Registrations)
                .ThenInclude(r => r.RegisterCourse)
                .ThenInclude(c => c.Teacher)
                .Where(s => s.Registrations.Any(r =>
                    r.RegisterCourse.Teacher.Name.ToLower().Contains(teacherName.ToLower()) &&
                    r.RegisterCourse.Course.Name.ToLower().Contains(courseName.ToLower())))
                .Select(s => new StudentDTO
                {
                    Name = s.Name,
                    Email = s.Email,
                    PhoneNumber = s.PhoneNumber,
                    City = s.City
                })
                .ToListAsync();

            if (students == null || students.Count == 0)
            {
                return NotFound();
            }

            return Ok(students);
        }

    }
}
