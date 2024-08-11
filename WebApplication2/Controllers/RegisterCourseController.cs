using Microsoft.AspNetCore.Mvc;
using WebApplication2.Entities;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.DTOs;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterCourseController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RegisterCourseController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RegisterCourseDTO>> GetAll()
        {
            var registerCourses = _context.RegisterCourses
                .Select(rc => new RegisterCourseDTO
                {
                    Id = rc.Id,
                    CourseId = rc.CourseId,
                    TeacherId = rc.TeacherId,
                    BranchId = rc.BranchId,
                    SemesterId = rc.SemesterId
                })
                .ToList();

            return Ok(registerCourses);
        }

        [HttpGet("{id}")]
        public ActionResult<RegisterCourseDTO> Get(int id)
        {
            var registerCourse = _context.RegisterCourses
                .Select(rc => new RegisterCourseDTO
                {
                    Id = rc.Id,
                    CourseId = rc.CourseId,
                    TeacherId = rc.TeacherId,
                    BranchId = rc.BranchId,
                    SemesterId = rc.SemesterId
                })
                .FirstOrDefault(rc => rc.Id == id);

            if (registerCourse == null)
            {
                return NotFound();
            }

            return Ok(registerCourse);
        }

        [HttpPost]
        public ActionResult<RegisterCourseDTO> Post([FromBody] RegisterCourseDTO registerCourseModelDTO)
        {
            if (registerCourseModelDTO == null)
            {
                return BadRequest();
            }

            var registerCourse = new RegisterCourseModel
            {
                CourseId = registerCourseModelDTO.CourseId,
                TeacherId = registerCourseModelDTO.TeacherId,
                BranchId = registerCourseModelDTO.BranchId,
                SemesterId = registerCourseModelDTO.SemesterId
            };

            _context.RegisterCourses.Add(registerCourse);
            _context.SaveChanges();

            registerCourseModelDTO.Id = registerCourse.Id;

            return CreatedAtAction(nameof(Get), new { id = registerCourseModelDTO.Id }, registerCourseModelDTO);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] RegisterCourseDTO registerCourseModelDTO)
        {
            if (registerCourseModelDTO == null || id != registerCourseModelDTO.Id)
            {
                return BadRequest();
            }

            var existingRegisterCourse = _context.RegisterCourses.Find(id);
            if (existingRegisterCourse == null)
            {
                return NotFound();
            }

            existingRegisterCourse.CourseId = registerCourseModelDTO.CourseId;
            existingRegisterCourse.TeacherId = registerCourseModelDTO.TeacherId;
            existingRegisterCourse.BranchId = registerCourseModelDTO.BranchId;
            existingRegisterCourse.SemesterId = registerCourseModelDTO.SemesterId;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var registerCourse = _context.RegisterCourses.Find(id);
            if (registerCourse == null)
            {
                return NotFound();
            }

            _context.RegisterCourses.Remove(registerCourse);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
