using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.DataAccess.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using WebApplication2.DataAccess;
using WebApplication2.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private ApplicationDbContext _context;


        public AssignmentController(IWebHostEnvironment hostingEnvironment, ApplicationDbContext myDatabase)
        {
            _hostingEnvironment = hostingEnvironment;
            _context = myDatabase;
        }

        [HttpPost("add")]
        public IActionResult AddAssignment([FromBody] AssignmentViewModel assignmentView)
        {
            if(assignmentView == null || assignmentView.RegistrationId<=0)
            {
                return BadRequest("Assignment data is missing.");
            }
            var assignment = new Assignment
            {
                Title = assignmentView.Title,
                Description = assignmentView.Description,
                RegistrationId = assignmentView.RegistrationId
            };
            _context.Assignments.Add(assignment);
            return Ok("Assignment added successfully.");
        }



        [HttpPost("addwithfile")]
        public async Task<IActionResult> AddAssignmentWithFile([FromForm] AssignmentViewModel model, IFormFile? File)
        {
          
            if (File != null && File.Length > 0)
            {
                if (File.Length > (5 * 1024 * 1024))
                {
                    return BadRequest("Too big. that what she said ");
                }

                var uploadsDirectory = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");

                if (!Directory.Exists(uploadsDirectory))
                {
                    Directory.CreateDirectory(uploadsDirectory);
                }

                var filePath = Path.Combine(uploadsDirectory, File.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await File.CopyToAsync(stream);
                }

                Assignment assignment = new Assignment
                {
                    Title = model.Title,
                    Description = model.Description,
                    RegistrationId = model.RegistrationId,
                    FilePath = filePath
                };

                _context.Assignments.Add(assignment);
                _context.SaveChanges();

                return Ok("Assignment and file uploaded successfully.");
            }

            return BadRequest("No file provided.");
        }
        [HttpPost("addWithFileToDatabase")]
        public async Task<IActionResult> AddWithFileToDatabase([FromForm] AssignmentViewModel model, IFormFile? File)
        {

            if (File != null && File.Length > 0)
            {
                if (File.Length > (5 * 1024 * 1024))
                {
                    return BadRequest("Too big. that what she said ");
                }

                using (var memoryStream = new MemoryStream())
                {
                    await File.CopyToAsync(memoryStream);

                    Assignment assignment = new Assignment
                    {
                        Title = model.Title,
                        Description = model.Description,
                        RegistrationId = model.RegistrationId,
                        FileData = memoryStream.ToArray(),
                    };

                    _context.Assignments.Add(assignment);
                    _context.SaveChanges();

                    return Ok("Assignment and file uploaded successfully.");
                }
            }

            return BadRequest("No file provided.");
        }

    }
}