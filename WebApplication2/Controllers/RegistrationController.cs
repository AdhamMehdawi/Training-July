using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
        List<registrationModel> registrationList;

        public RegistrationController()
        {

            FillStudents();
            FillCourses();
        }
        void FillStudents()
        {
            students = new List<Student>();
            for(int i=0;i<20;i++)
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
            if(registration==null || registration.StudentId < 1 || registration.CourseId < 1)
            {
                return BadRequest("invalid registration form");
            }
            var student = students.FirstOrDefault(x => x.Id == registration.StudentId);
            var course = Courses.FirstOrDefault(x => x.Id == registration.CourseId);
            if(student==null)
            {
                return NotFound("Student not found");
            }
            if(course==null)
            {
                return NotFound("course not found");
            }
            var reg = new registrationModel();
            reg.CourseId = course.Id;
            reg.StudentId = student.Id;
            reg.Course = course;
            reg.Student = student;
            reg.RegistrationDate = DateTime.Now;
            return Ok(reg);

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(id<1)
            {
                return BadRequest("Invalid Id");
            }
            var register = registrationList.FirstOrDefault(x => x.Id == id);
            if(register == null)
            {
                return NotFound("registeration not found");
            }
            registrationList.Remove(register);
            return Ok("registation removed");
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, Registration registration)
        {
            if (id < 1 || registration == null || registration.StudentId < 1 || registration.CourseId < 1)
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
            var register = registrationList.FirstOrDefault(x => x.Id == id);
            if (register == null)
            {
                return NotFound("registeration not found");
            }
            register.CourseId = course.Id;
            register.StudentId = student.Id;
            register.Course = course;
            register.Student = student;
            register.RegistrationDate = DateTime.Now;
            return Ok(register);
        }

        [HttpGet("bananan")]
        public IActionResult HashCode(int id ,int number ,DateTime date,int cvs)
        {
            var hashed =id*10 + number+55 + "csdqwf@#@#@4"+(date+"555") + cvs % 20+"sdasd";

            return Ok(hashed);
        }
    }
}
