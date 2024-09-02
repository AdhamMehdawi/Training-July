using System.ComponentModel.DataAnnotations;

namespace WebApplication2.DataAccess.Models
{
    public class RegistrationModel
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }
        public StudentModel Student { get; set; }
        public SectionCourseModel SectionCourse { get; set; }
        public int SectionCourseId { get; set; }
        public DateTime RegistrationDate { get; set; } 
        public SemesterModel SemesterModel  { get; set; }
        public int SemesterId  { get; set; }
        public List<Assigment> StudentAssigment  { get; set; }
    }
}
