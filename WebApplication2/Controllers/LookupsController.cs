using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Application.DtoModels;
using WebApplication2.DataAccess;
using WebApplication2.DataAccess.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupsController : ControllerBase
    {
        private MyDatabase _database;
        public LookupsController(MyDatabase database)
        {
            _database = database;
        }

        [HttpGet("GetSections")]
        public IActionResult GetSections()
        {
            return Ok(_database.Section.ToList());
        }

        [HttpGet("SearchByName")]
        public IActionResult SearchByName([FromQuery] string name, [FromQuery] int a)
        {
            var results = _database.Section
                .Where(c => c.Name.Contains(name))
                .ToList(); 
            if (a == 1)
                return Ok(results);
            return Ok("Please send a as a 1");
        }


        [HttpPost("Create")]
        public IActionResult CreateSection(SectionDto section)
        {
            var sectionModel = new SectionModel();
            sectionModel.Id = section.Id;
            sectionModel.Name = section.Name;
            _database.Section.Add(sectionModel);
            _database.SaveChanges();
            return Ok();
        }


        [HttpPut("Edit")]
        public IActionResult EditSection(SectionDto sectionDto)
        {
            if (sectionDto.Id > 0)
            {
                var section = _database.Section.Find(sectionDto.Id);
                if (section == null) return NotFound();
                section.Name = sectionDto.Name;
                _database.SaveChanges();
                return Accepted();
            }
            return BadRequest("Incorrect Id value");
        }


        [HttpDelete("Delete")]
        public IActionResult DeleteSection(int sectionId)
        {
            if (sectionId > 0)
            {
                var section = _database.Section.Find(sectionId);
                if (section == null) return NotFound();
                _database.Section.Remove(section);
                _database.SaveChanges();
            }
            return Ok();
        }

        [HttpGet("GetStudents")]
        public IActionResult GetStudents()
        {
            var result=_database.Students
                .Where(c=>c.Id > 0)
                .Select(c=>new StudentData
                {
                    Id = c.Id,
                    Name = c.Name
                });
            var queryString = result.ToQueryString();
            return Ok(result);
        }

    }


    public class StudentData
    {
        public int Id { get; set; } 
        public string Name { get; set; } 
    }
}
