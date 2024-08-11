using Microsoft.AspNetCore.Mvc;
using WebApplication2.Entities;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.DTOs;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BranchController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BranchDTO>> GetAll()
        {
            var branches = _context.Branches
                .Select(b => new BranchDTO
                {
                    Id = b.Id,
                    Name = b.Name
                })
                .ToList();

            return Ok(branches);
        }

        [HttpGet("{id}")]
        public ActionResult<BranchDTO> Get(int id)
        {
            var branch = _context.Branches
                .Select(b => new BranchDTO
                {
                    Id = b.Id,
                    Name = b.Name
                })
                .FirstOrDefault(b => b.Id == id);

            if (branch == null)
            {
                return NotFound();
            }

            return Ok(branch);
        }

        [HttpPost]
        public ActionResult<BranchDTO> Post([FromBody] BranchDTO branchModelDTO)
        {
            if (branchModelDTO == null)
            {
                return BadRequest();
            }

            var branch = new BranchModel
            {
                Name = branchModelDTO.Name
            };

            _context.Branches.Add(branch);
            _context.SaveChanges();

            branchModelDTO.Id = branch.Id;

            return CreatedAtAction(nameof(Get), new { id = branchModelDTO.Id }, branchModelDTO);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BranchDTO branchModelDTO)
        {
            if (branchModelDTO == null || id != branchModelDTO.Id)
            {
                return BadRequest();
            }

            var existingBranch = _context.Branches.Find(id);
            if (existingBranch == null)
            {
                return NotFound();
            }

            existingBranch.Name = branchModelDTO.Name;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var branch = _context.Branches.Find(id);
            if (branch == null)
            {
                return NotFound();
            }

            _context.Branches.Remove(branch);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
