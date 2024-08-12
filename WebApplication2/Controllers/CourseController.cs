using Microsoft.AspNetCore.Mvc;
using WebApplication2.Entities;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.DTOs;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CourseController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CourseDTO>> GetAll()
        {
            var courses = _context.Courses
                .Select(c => new CourseDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description
                })
                .ToList();

            return Ok(courses);
        }

        [HttpGet("{id}")]
        public ActionResult<CourseDTO> Get(int id)
        {   
            var course = _context.Courses
                .Select(c => new CourseDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description
                })
                .FirstOrDefault(c => c.Id == id);

            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        [HttpPost]
        public ActionResult<CourseDTO> Post([FromBody] CourseDTO courseModelDTO)
        {
            if (courseModelDTO == null)
            {
                return BadRequest();
            }

            var course = new CourseModel
            {
                Name = courseModelDTO.Name,
                Description = courseModelDTO.Description
            };

            _context.Courses.Add(course);
            _context.SaveChanges();

            courseModelDTO.Id = course.Id;

            return CreatedAtAction(nameof(Get), new { id = courseModelDTO.Id }, courseModelDTO);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CourseDTO courseModelDTO)
        {
            if (courseModelDTO == null || id != courseModelDTO.Id)
            {
                return BadRequest();
            }

            var existingCourse = _context.Courses.Find(id);
            if (existingCourse == null)
            {
                return NotFound();
            }

            existingCourse.Name = courseModelDTO.Name;
            existingCourse.Description = courseModelDTO.Description;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var course = _context.Courses.Find(id);
            if (course == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(course);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
