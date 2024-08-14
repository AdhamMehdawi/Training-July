using System.ComponentModel.DataAnnotations;
using WebApplication2.DataAccess.Models;

namespace WebApplication2.Application.DtoModels
{
    public class RegistrationData
    {
        public StudentModel student;


        public RegistrationData(StudentModel student)
        {
            this.student = student;
        }
        public RegistrationData()
        {
            
        }

        public int Id { get; set; }
            public int StudentId { get; set; }
            public StudentModel Student { get; set; }
            public SectionCourseModel SectionCourse { get; set; }
            public int SectionCourseId { get; set; }
            public int RegistrationYear { get; set; }
            public SemesterModel SemesterModel { get; set; }
            public int SemesterId { get; set; }
    }
}
