using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        List<Student> students;
        List<Course> Courses;

        public RegistrationController()
        {
            students = new List<Student>();
            Courses = new List<Course>();
        }

        [HttpPost]
        public IActionResult Register(Registration registration)
        {
            var student = students.Find(c => c.Id == registration.StudentId);
            var course = Courses.Find(c => c.Id == registration.CourseId);
            if (student == null || course == null)
            {
                return BadRequest();
            }
            
            //register 

            return Ok(registration);
        }
    }
}
