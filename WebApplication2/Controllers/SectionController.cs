using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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
            if(section == null)
            {
                return BadRequest();
            }
            if(section.Id <= 0)
            {
                return BadRequest();
            }
            var cor= _context.Section.Find(section.Id);
            if (cor == null)
            {
                return NotFound();
            }
            
            cor.Name=section.Name;   
            _context.SaveChanges();

            return Ok(cor);

        }
        [HttpGet("SerchByName")]
        public IActionResult search(string name)
        {
           
            var sec=_context.Section.Where(t => t.Name.Contains(name)).ToList();
            List<SsectionDT> sections = new List<SsectionDT>();
            if (sec == null)
            {
                return NotFound();
            }
            foreach (var x in sec)
                {
                sections.Add(new SsectionDT()
                {
                    Id = x.Id,
                    Name = x.Name
                });
            }


            return Ok(sections);
        }
        [HttpGet("SerchByNameQuery")]
        public IActionResult searchQ(string name,int a)
        {

            var sec = _context.Section.Where(t => t.Name.Contains(name));
            var stringQuery = sec.ToQueryString();    
            if(a==1)
            {
                return Ok(stringQuery);
            }
            return Ok("Please send a as 1");
        }



    }
}
