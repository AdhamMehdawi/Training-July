using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using WebApplication2.DataAccess;
using WebApplication2.DataAccess.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssigmentController : ControllerBase
    {
        private readonly MyDatabase _database;
        public AssigmentController(MyDatabase database)
        {
            _database = database;
        }


        [HttpPost]
        public IActionResult CrateAssigment( IFormFile file )
        {
            var assigment = new Assigment();
            //{
            //    Description = assigmentModel.Description,
            //    Title = assigmentModel.Title,
            //    RegistrationId = assigmentModel.RegistrationId,
            //};
            _database.Assigment.Add(assigment);
            _database.SaveChanges();
            return Ok(assigment);
        }


        [HttpGet("studentCourses/{studentId}")]
        public IActionResult GetStudentCourses(int studentId)
        {
            var result = _database.Registration
                .Where(c => c.StudentId == studentId)
                .ToList();
       
            return Ok(result);
        }

    }

    public class  AssigmentModel 
    {
        [Required]
        public string Title { get; set; }
        [Required]
        [MaxLength(600)]
        public string Description { get; set; }
        public int RegistrationId { get; set; } 
        public IFormFile File { get; set; }
    }
}
