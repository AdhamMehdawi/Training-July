using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("Test/{id}")]
        public IActionResult TestPost(int id, [FromQuery] int testval, [FromBody] AssigmentModel model )
        {
            return Ok(id+testval);
        }

        [HttpPost]
        public IActionResult CrateAssigment(IFormFile file)
        {
            if (file.Length > (5 * 1024 * 1024))
            {
                return BadRequest("The fle size is grater than  5mb");
            }
            var path = SaveFileToLocalPath(file);
            var fileContent = ConvertToStream(file);

            var assigment = new Assigment
            {
                Description = "Description",
                Title = "Title",
                RegistrationId = 2,
                FileName = file.FileName,
                FilePath = path,
                FileContent = fileContent
            };
            _database.Assigment.Add(assigment);
            _database.SaveChanges();
            return Ok(assigment);
        }

        private byte[] ConvertToStream(IFormFile file)
        {
            var memoryStream = new MemoryStream();
            file.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }

        private string SaveFileToLocalPath(IFormFile file)
        {
            var filepath = Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot/uploads",
                file.FileName);
            if (Path.Exists(filepath))
            {
                var filenameChange = file.FileName.Split('.');
                var newFileName = filenameChange[0] + "(1)" + filenameChange[1];
                filepath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot/uploads",
                    newFileName);
                var streem = new FileStream(filepath, FileMode.Create);
                file.CopyTo(streem);
                return filepath;
            }
            else
            {
                var streem = new FileStream(filepath, FileMode.Create);
                file.CopyTo(streem);
                return filepath;
            }

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

    public class AssigmentModel
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
