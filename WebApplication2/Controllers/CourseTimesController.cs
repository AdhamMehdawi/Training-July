using Microsoft.AspNetCore.Mvc;
using WebApplication2.Entities;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.DTOs;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseTimesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CourseTimesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CourseTimesDTO>> GetAll()
        {
            var courseTimes = _context.CourseTimes
                .Select(ct => new CourseTimesDTO
                {
                    Id = ct.Id,
                    RegisterCourseId = ct.RegisterCourseId,
                    Day = ct.Day,
                    StartTime = ct.StartTime,
                    EndTime = ct.EndTime,
                    HallId = ct.HallId
                })
                .ToList();

            return Ok(courseTimes);
        }

        [HttpGet("{id}")]
        public ActionResult<CourseTimesDTO> Get(int id)
        {
            var courseTime = _context.CourseTimes
                .Select(ct => new CourseTimesDTO
                {
                    Id = ct.Id,
                    RegisterCourseId = ct.RegisterCourseId,
                    Day = ct.Day,
                    StartTime = ct.StartTime,
                    EndTime = ct.EndTime,
                    HallId = ct.HallId
                })
                .FirstOrDefault(ct => ct.Id == id);

            if (courseTime == null)
            {
                return NotFound();
            }

            return Ok(courseTime);
        }

        [HttpPost]
        public ActionResult<CourseTimesDTO> Post([FromBody] CourseTimesDTO courseTimesModelDTO)
        {
            if (courseTimesModelDTO == null)
            {
                return BadRequest();
            }

            var courseTime = new CourseTimesModel
            {
                RegisterCourseId = courseTimesModelDTO.RegisterCourseId,
                Day = courseTimesModelDTO.Day,
                StartTime = courseTimesModelDTO.StartTime,
                EndTime = courseTimesModelDTO.EndTime,
                HallId = courseTimesModelDTO.HallId
            };

            _context.CourseTimes.Add(courseTime);
            _context.SaveChanges();

            courseTimesModelDTO.Id = courseTime.Id;

            return CreatedAtAction(nameof(Get), new { id = courseTimesModelDTO.Id }, courseTimesModelDTO);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CourseTimesDTO courseTimesModelDTO)
        {
            if (courseTimesModelDTO == null || id != courseTimesModelDTO.Id)
            {
                return BadRequest();
            }

            var existingCourseTime = _context.CourseTimes.Find(id);
            if (existingCourseTime == null)
            {
                return NotFound();
            }

            existingCourseTime.RegisterCourseId = courseTimesModelDTO.RegisterCourseId;
            existingCourseTime.Day = courseTimesModelDTO.Day;
            existingCourseTime.StartTime = courseTimesModelDTO.StartTime;
            existingCourseTime.EndTime = courseTimesModelDTO.EndTime;
            existingCourseTime.HallId = courseTimesModelDTO.HallId;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var courseTime = _context.CourseTimes.Find(id);
            if (courseTime == null)
            {
                return NotFound();
            }

            _context.CourseTimes.Remove(courseTime);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
