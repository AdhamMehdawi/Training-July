using WebApplication2.Controllers;

namespace WebApplication2
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
    }

    public class Registration
    {
        //public Student Student { get; set; }
        //public Course Course { get; set; } 
        public int id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime RegistrationDate { get; set; }

    }


    public class registrationModel
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
