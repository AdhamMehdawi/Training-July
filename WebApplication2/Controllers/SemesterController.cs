using Microsoft.AspNetCore.Mvc;
using WebApplication2.Entities;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.DTOs;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SemesterController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SemesterController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SemesterDTO>> GetAll()
        {
            var semesters = _context.Semesters
                .Select(s => new SemesterDTO
                {
                    SemesterNumber = s.SemesterNumber,
                    SemesterName = s.SemesterName,
                    Year = s.Year
                })
                .ToList();

            return Ok(semesters);
        }

        [HttpGet("{id}")]
        public ActionResult<SemesterDTO> Get(int id)
        {
            var semester = _context.Semesters
                .Select(s => new SemesterDTO
                {
                    SemesterNumber = s.SemesterNumber,
                    SemesterName = s.SemesterName,
                    Year = s.Year
                })
                .FirstOrDefault(s => s.SemesterNumber == id);

            if (semester == null)
            {
                return NotFound();
            }

            return Ok(semester);
        }

        [HttpPost]
        public ActionResult<SemesterDTO> Post([FromBody] SemesterDTO semesterModelDTO)
        {
            if (semesterModelDTO == null)
            {
                return BadRequest();
            }

            var semester = new SemesterModel
            {
                SemesterNumber = semesterModelDTO.SemesterNumber,
                SemesterName = semesterModelDTO.SemesterName,
                Year = semesterModelDTO.Year
            };

            _context.Semesters.Add(semester);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = semesterModelDTO.SemesterNumber }, semesterModelDTO);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SemesterDTO semesterModelDTO)
        {
            if (semesterModelDTO == null || id != semesterModelDTO.SemesterNumber)
            {
                return BadRequest();
            }

            var existingSemester = _context.Semesters.Find(id);
            if (existingSemester == null)
            {
                return NotFound();
            }

            existingSemester.SemesterName = semesterModelDTO.SemesterName;
            existingSemester.Year = semesterModelDTO.Year;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var semester = _context.Semesters.Find(id);
            if (semester == null)
            {
                return NotFound();
            }

            _context.Semesters.Remove(semester);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
