 
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
        [HttpGet("GetRegistration")]
        public IActionResult GetRegistration()
        {
            var data = _database.Registration.ToList();
            var registrationList = new List<RegistrationModel>();
            foreach (var reg in data)
            {
                var student = _database.Students.FirstOrDefault(c => c.Id == reg.StudentId);
                var sectionCourse = _database.SectionCourse.FirstOrDefault(c => c.Id == reg.SectionCourseId);
                var semester = _database.Semesters.FirstOrDefault(c => c.SemesterNumber == reg.SemesterId);

                if (student == null || sectionCourse == null || semester == null)
                {
                    continue;
                }

                var registration = new RegistrationModel()
                {
                    Id = reg.Id,
                    StudentId = reg.StudentId,
                    RegistrationYear = reg.RegistrationYear,
                    SemesterId = reg.SemesterId,
                    Student = new StudentModel
                    {
                        Id = student.Id,
                        Name = student.Name,
                        City = student.City,
                        Email = student.Email,
                        PhoneNumber = student.PhoneNumber,
                    },
                    SectionCourse = new SectionCourseModel
                    {
                        Id = sectionCourse.Id,
                        courseId = sectionCourse.Id,
                        SectionId = sectionCourse.Id,
                        TeacherId = sectionCourse.Id,
                        EndTime = sectionCourse.EndTime,
                        StartTime = sectionCourse.StartTime,
                    },
                    SemesterModel = new SemesterModel
                    {
                        SemesterNumber = semester.SemesterNumber,
                        SemesterName = semester.SemesterName,
                    }
                };


                registrationList.Add(registration);
            }
/*
            foreach (var reg in data)
            {
                // استخدم FirstOrDefault للعثور على عنصر واحد بدلاً من ToList
                var student = _database.Students.FirstOrDefault(c => c.Id == reg.StudentId);
                var sectionCourse = _database.SectionCourse.FirstOrDefault(c => c.Id == reg.SectionCourseId);
                var semester = _database.Semesters.FirstOrDefault(c => c.SemesterNumber == reg.SemesterId);

                if (student == null || sectionCourse == null || semester == null)
                {
                    continue;
                }

                var registration = new RegistrationModel()
                {
                    Id = reg.Id,
                    StudentId = reg.StudentId,
                    RegistrationYear = reg.RegistrationYear,
                    SemesterId = reg.SemesterId,
                   // Student = student,
                   // SectionCourse = sectionCourse,
                   // SemesterModel = semester,
                };

                registrationList.Add(registration);
            }
*/
            return Ok(registrationList);
        }


        [HttpGet("GetSemesters")]
        public IActionResult GetSemesters()
        {
            return Ok(_database.Semesters.ToList());
        }
        [HttpGet("GetTeachers")]
        public IActionResult GetTeachers()
        {
            return Ok(_database.Teachers.ToList());
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


        [HttpPost("Registration")]
        public IActionResult RegisterStudent([FromBody] RegDto reg)
        {
            //validate the student id 
            if (!_database.Students.Any(c=>c.Id == reg.StudentId))
            {
                return BadRequest("The student Id does not exists!!");
            }
            if (!_database.Courses.Any(c => c.Id == reg.CourseId))
            {
                return BadRequest("The course Id does not exists!!");
            }
            //1. try to get the section course using the course id 
            var listOfSectionCourse= _database.SectionCourse
                .Where(c => c.courseId == reg.CourseId).ToList();
            int sectionCourseId = 0;
           if (listOfSectionCourse.Any())
           {
               sectionCourseId= listOfSectionCourse.FirstOrDefault().Id;
           }
           else // no data in the section course 
           {
               //create a new row for the section course 
               var sectionCourse = new SectionCourseModel()
               {
                   SectionId = 1,
                   TeacherId = 1,
                   courseId = 1,
                   StartTime = TimeSpan.FromDays(1),
                   EndTime = TimeSpan.FromDays(2)
               };
               _database.SectionCourse.Add(sectionCourse);
               _database.SaveChanges();
               sectionCourseId= sectionCourse.Id;
           }
           //2. insert into the registration table 
           _database.Registration.Add(new RegistrationModel()
           {
               StudentId = reg.StudentId,
               SemesterId = 1,
               SectionCourseId = sectionCourseId,
               RegistrationYear = DateTime.Now.Year
           });
           _database.SaveChanges();

            return Ok();
        }

    }


    public class StudentData
    {
        public int Id { get; set; } 
        public string Name { get; set; } 
    }
}
