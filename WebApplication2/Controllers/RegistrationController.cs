using Microsoft.AspNetCore.Mvc;
using WebApplication2.Entities;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.DTOs;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterStudentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RegisterStudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RegisterStudentDTO>> GetAll()
        {
            var registerStudents = _context.Registrations
                .Select(rs => new RegisterStudentDTO
                {
                    Id = rs.Id,
                    StudentId = rs.StudentId,
                    RegisterCourseId = rs.RegisterCourseId,
                    RegistrationDate = rs.RegistrationDate,
                    BranchId = rs.BranchId
                })
                .ToList();

            return Ok(registerStudents);
        }

        [HttpGet("{id}")]
        public ActionResult<RegisterStudentDTO> Get(int id)
        {
            var registerStudent = _context.Registrations
                .Select(rs => new RegisterStudentDTO
                {
                    Id = rs.Id,
                    StudentId = rs.StudentId,
                    RegisterCourseId = rs.RegisterCourseId,
                    RegistrationDate = rs.RegistrationDate,
                    BranchId = rs.BranchId
                })
                .FirstOrDefault(rs => rs.Id == id);

            if (registerStudent == null)
            {
                return NotFound();
            }

            return Ok(registerStudent);
        }

        [HttpPost]
        public ActionResult<RegisterStudentDTO> Post([FromBody] RegisterStudentDTO registerStudentModelDTO)
        {
            if (registerStudentModelDTO == null)
            {
                return BadRequest();
            }

            var registerStudent = new RegisterStudentModel
            {
                StudentId = registerStudentModelDTO.StudentId,
                RegisterCourseId = registerStudentModelDTO.RegisterCourseId,
                RegistrationDate = registerStudentModelDTO.RegistrationDate,
                BranchId = registerStudentModelDTO.BranchId
            };

            _context.Registrations.Add(registerStudent);
            _context.SaveChanges();

            registerStudentModelDTO.Id = registerStudent.Id;

            return CreatedAtAction(nameof(Get), new { id = registerStudentModelDTO.Id }, registerStudentModelDTO);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] RegisterStudentDTO registerStudentModelDTO)
        {
            if (registerStudentModelDTO == null || id != registerStudentModelDTO.Id)
            {
                return BadRequest();
            }

            var existingRegisterStudent = _context.Registrations.Find(id);
            if (existingRegisterStudent == null)
            {
                return NotFound();
            }

            existingRegisterStudent.StudentId = registerStudentModelDTO.StudentId;
            existingRegisterStudent.RegisterCourseId = registerStudentModelDTO.RegisterCourseId;
            existingRegisterStudent.RegistrationDate = registerStudentModelDTO.RegistrationDate;
            existingRegisterStudent.BranchId = registerStudentModelDTO.BranchId;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var registerStudent = _context.Registrations.Find(id);
            if (registerStudent == null)
            {
                return NotFound();
            }

            _context.Registrations.Remove(registerStudent);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
