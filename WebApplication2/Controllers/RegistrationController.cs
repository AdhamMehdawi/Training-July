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

            FillStudents();
            FillCourses();
        }
        void FillStudents()
        {
            students = new List<Student>();
            for (int i = 0; i < 20; i++)
            {
                var student = new Student();
                student.Id = i;
                student.Name = "A_" + i.ToString();
                student.Dob = DateTime.Now;
                student.IsActive = i % 2 == 0;
                student.Address = new Address();
                student.Address.Street = "street_" + i;
                student.Address.City = "City_" + i;
                student.Address.AddressDescription = "Description_" + i;
                student.BuildingAddress = new List<Address>();
                for (int j = 0; j < 3; j++)
                {
                    var buildingAddress = new Address();
                    buildingAddress.AddressDescription = "Description_" + i + "_" + j;
                    buildingAddress.City = "City_" + i + "_" + j;
                    buildingAddress.Street = "Street_" + i + "_" + j;
                    student.BuildingAddress.Add(buildingAddress);
                }
                students.Add(student);
            }
        }
        void FillCourses()
        {
            Courses = new List<Course>();
            for (int i = 0; i < 20; i++)
            {
                var course = new Course();
                course.Id = i;
                course.Name = "Course_" + i.ToString();
                course.SerialNumber = "SerialNumber_" + i;
                Courses.Add(course);
            }
        }

        [HttpPost]
        public IActionResult Register(Registration registration)
        {
            if (registration == null || registration.StudentId < 1 || registration.CourseId < 1)
            {
                return BadRequest("invalid registration form");
            }
            var student = students.FirstOrDefault(x => x.Id == registration.StudentId);
            var course = Courses.FirstOrDefault(x => x.Id == registration.CourseId);
            if (student == null)
            {
                return NotFound("Student not found");
            }
            if (course == null)
            {
                return NotFound("course not found");
            }
            var registrationModel = new WebApplication2.DataAccess.Models.RegistrationModel();
            registrationModel.StudentId = student.Id;
            registrationModel.CourseId = course.Id;
            registrationModel.Student = student;
            registrationModel.Course = course;
            registrationModel.RegistrationDate = DateTime.Now;
            return Ok(registrationModel);

        }

        [HttpPut]
        public IActionResult Update([FromQuery]int regId,[FromBody]Registration registration)
        {
            //update registration based on teh regid
            //
            return Ok();
        }

        [HttpPut("Update")]
        public IActionResult Update1([FromHeader] int regId, [FromBody] Registration registration)
        {
            //update registration based on teh regid
            //
            return Ok();
        }
    }
}
