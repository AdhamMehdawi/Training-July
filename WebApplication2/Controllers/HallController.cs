using Microsoft.AspNetCore.Mvc;
using WebApplication2.Entities;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.DTOs;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HallController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HallController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<HallDTO>> GetAll()
        {
            var halls = _context.Halls
                .Select(h => new HallDTO
                {
                    Id = h.Id,
                    Name = h.Name,
                    Capacity = h.Capacity
                })
                .ToList();

            return Ok(halls);
        }

        [HttpGet("{id}")]
        public ActionResult<HallDTO> Get(int id)
        {
            var hall = _context.Halls
                .Select(h => new HallDTO
                {
                    Id = h.Id,
                    Name = h.Name,
                    Capacity = h.Capacity
                })
                .FirstOrDefault(h => h.Id == id);

            if (hall == null)
            {
                return NotFound();
            }

            return Ok(hall);
        }

        [HttpPost]
        public ActionResult<HallDTO> Post([FromBody] HallDTO hallModelDTO)
        {
            if (hallModelDTO == null)
            {
                return BadRequest();
            }

            var hall = new HallModel
            {
                Name = hallModelDTO.Name,
                Capacity = hallModelDTO.Capacity
            };

            _context.Halls.Add(hall);
            _context.SaveChanges();

            hallModelDTO.Id = hall.Id;

            return CreatedAtAction(nameof(Get), new { id = hallModelDTO.Id }, hallModelDTO);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] HallDTO hallModelDTO)
        {
            if (hallModelDTO == null || id != hallModelDTO.Id)
            {
                return BadRequest();
            }

            var existingHall = _context.Halls.Find(id);
            if (existingHall == null)
            {
                return NotFound();
            }

            existingHall.Name = hallModelDTO.Name;
            existingHall.Capacity = hallModelDTO.Capacity;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var hall = _context.Halls.Find(id);
            if (hall == null)
            {
                return NotFound();
            }

            _context.Halls.Remove(hall);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
