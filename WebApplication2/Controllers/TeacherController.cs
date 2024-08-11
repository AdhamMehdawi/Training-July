using Microsoft.AspNetCore.Mvc;
using WebApplication2.Entities;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.DTOs;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TeacherController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TeacherDTO>> GetAll()
        {
            var teachers = _context.Teachers
                .Select(t => new TeacherDTO
                {
                    Id = t.Id,
                    Name = t.Name,
                    Email = t.Email
                })
                .ToList();

            return Ok(teachers);
        }

        [HttpGet("{id}")]
        public ActionResult<TeacherDTO> Get(int id)
        {
            var teacher = _context.Teachers
                .Select(t => new TeacherDTO
                {
                    Id = t.Id,
                    Name = t.Name,
                    Email = t.Email
                })
                .FirstOrDefault(t => t.Id == id);

            if (teacher == null)
            {
                return NotFound();
            }

            return Ok(teacher);
        }

        [HttpPost]
        public ActionResult<TeacherDTO> Post([FromBody] TeacherDTO teacherModelDTO)
        {
            if (teacherModelDTO == null)
            {
                return BadRequest();
            }

            var teacher = new TeacherModel
            {
                Name = teacherModelDTO.Name,
                Email = teacherModelDTO.Email
            };

            _context.Teachers.Add(teacher);
            _context.SaveChanges();

            teacherModelDTO.Id = teacher.Id;

            return CreatedAtAction(nameof(Get), new { id = teacherModelDTO.Id }, teacherModelDTO);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TeacherDTO teacherModelDTO)
        {
            if (teacherModelDTO == null || id != teacherModelDTO.Id)
            {
                return BadRequest();
            }

            var existingTeacher = _context.Teachers.Find(id);
            if (existingTeacher == null)
            {
                return NotFound();
            }

            existingTeacher.Name = teacherModelDTO.Name;
            existingTeacher.Email = teacherModelDTO.Email;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var teacher = _context.Teachers.Find(id);
            if (teacher == null)
            {
                return NotFound();
            }

            _context.Teachers.Remove(teacher);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
