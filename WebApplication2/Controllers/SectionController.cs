using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.DataAccess;
using WebApplication2.DataAccess.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private readonly MyDatabase _context;

        public SectionController(MyDatabase context)
        {
            _context = context;
        }

        [HttpGet("GetAllCourses")]
        public IActionResult GetAllCourses()
        {
           var cor=_context.Cources.ToList();

            if(cor == null)
            {
                return NotFound();
            }
            return Ok(cor);
        }
        [HttpPost("AddSection")]
        public IActionResult AddSection(SsectionDT section)
        {
            if (section == null)
            {
                return BadRequest();
            }
            var cor=new SectionModel() { 
                Id = section.Id,
                Name = section.Name

            };
            _context.Section.Add(cor);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPost("addCourse")]
        public IActionResult AddCourse(CourceModel course)
        {
            if (course == null)
            {
                return BadRequest();
            }
            _context.Cources.Add(course);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPost("AddSectionCourse")]
        public IActionResult AddSectionCourse(SectionCorseModel sectionCourse)
        {
            if (sectionCourse == null)
            {
                return BadRequest();
            }
            _context.SectionCourse.Add(sectionCourse);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPut("UpdateSection")]
        public IActionResult Update(SsectionDT section)
        {

            var cor= _context.Section.Find(section.Id);
            if (cor == null)
            {
                return NotFound();
            }
            cor.Id = section.Id;
            cor.Name=section.Name;   
            _context.SaveChanges();

            return Ok(cor);

        }

    }
}
